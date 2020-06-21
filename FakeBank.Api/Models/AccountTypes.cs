using System.Collections.Generic;

namespace FakeBank.Api.Models
{
    public partial class AccountTypes
    {
        public AccountTypes()
        {
            UserAccounts = new HashSet<UserAccounts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserAccounts> UserAccounts { get; set; }
    }
}
