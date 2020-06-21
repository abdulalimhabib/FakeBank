using System;

namespace FakeBank.Api.Models
{
    public partial class AccountTransactions
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public virtual UserAccounts Account { get; set; }
    }
}
