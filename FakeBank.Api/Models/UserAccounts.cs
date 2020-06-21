using System;
using System.Collections.Generic;

namespace FakeBank.Api.Models
{
    public partial class UserAccounts
    {
        public UserAccounts()
        {
            AccountTransactions = new HashSet<AccountTransactions>();
            AccountTransfersSourceAccount = new HashSet<AccountTransfers>();
            AccountTransfersTargetAccount = new HashSet<AccountTransfers>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public decimal Balance { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        public string Nickname { get; set; }

        public virtual AccountTypes Type { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<AccountTransactions> AccountTransactions { get; set; }
        public virtual ICollection<AccountTransfers> AccountTransfersSourceAccount { get; set; }
        public virtual ICollection<AccountTransfers> AccountTransfersTargetAccount { get; set; }
    }
}
