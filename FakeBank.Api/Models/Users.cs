using System;
using System.Collections.Generic;

namespace FakeBank.Api.Models
{
    public partial class Users
    {
        public Users()
        {
            UserAccounts = new HashSet<UserAccounts>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }

        public virtual ICollection<UserAccounts> UserAccounts { get; set; }
    }
}
