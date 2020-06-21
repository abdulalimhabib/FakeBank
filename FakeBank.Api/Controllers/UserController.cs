using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeBank.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FakeBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        #region " Private Fields "

        //private readonly ILogger<UserController> _logger;
        private readonly FakeBankContext _context;

        #endregion

        #region " Constructors "

        public UserController(FakeBankContext context)
        {
            //_logger = logger;
            _context = context;

        }
        #endregion

        #region " Api Methods "

        [HttpGet("GetUsers")]
        public async Task<IEnumerable<Users>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("GetUser/{id}")]
        public async Task<Users> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Id == id);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, Users user)
        {
            if (user.Id != id) return BadRequest();

            user.LastModifiedOn = DateTimeOffset.Now;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!UserExists(id)) return NotFound();

                throw;
            }

            return NoContent();

        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(Users user)
        {

            if (UserNameExists(user.UserName)) return Problem($"User name {user.UserName} already exists");

            user.CreatedOn = DateTimeOffset.Now;
            user.LastModifiedOn = DateTimeOffset.Now;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);

        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult<Users>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        #endregion

        #region " Private Functions "

        private bool UserExists(int id)
        {
            return _context.Users.Any(a => a.Id == id);
        }

        private bool UserNameExists(string userName)
        {
            return _context.Users.Any(a => a.UserName == userName);
        }

        #endregion

    }
}
