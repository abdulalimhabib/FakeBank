using System;

namespace FakeBank.Api.Models
{
    public partial class AccountTransfers
    {
        public int Id { get; set; }
        public int SourceAccountId { get; set; }
        public int TargetAccountId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public decimal Amount { get; set; }

        public virtual UserAccounts SourceAccount { get; set; }
        public virtual UserAccounts TargetAccount { get; set; }
    }
}
