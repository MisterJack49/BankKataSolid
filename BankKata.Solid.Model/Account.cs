using BankKata.Solid.Interfaces.Model;
using System;

namespace BankKata.Solid.Model
{
    public class Account : IAccount
    {
        public Account(IAmount amount, IStatementCollection statementCollection)
        {
            Balance = amount ?? throw new ArgumentNullException(nameof(amount));
            StatementCollection = statementCollection ?? throw new ArgumentNullException(nameof(statementCollection));
        }

        public IAmount Balance { get; }
        public IStatementCollection StatementCollection { get; }
    }
}
