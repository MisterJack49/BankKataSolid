using BankKata.Solid.Interfaces;
using BankKata.Solid.Interfaces.Factories;
using BankKata.Solid.Interfaces.Model;
using BankKata.Solid.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace BankKata.Solid.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountFactory _accountFactory;
        private readonly IAmountFactory _amountFactory;
        private readonly IStatementCollectionFactory _statementCollectionFactory;
        private readonly IStatementFactory _statementFactory;
        public AccountService(IAccountFactory accountFactory, IAmountFactory amountFactory, IStatementCollectionFactory statementCollectionFactory, IStatementFactory statementFactory)
        {
            _accountFactory = accountFactory ?? throw new ArgumentNullException(nameof(accountFactory));
            _amountFactory = amountFactory ?? throw new ArgumentNullException(nameof(amountFactory));
            _statementCollectionFactory = statementCollectionFactory ?? throw new ArgumentNullException(nameof(statementCollectionFactory));
            _statementFactory = statementFactory ?? throw new ArgumentNullException(nameof(statementFactory));
        }

        public IAccount CreateAccount()
        {
            return _accountFactory.Create(
                _amountFactory.Create(0),
                _statementCollectionFactory.Create(new List<IStatement>()));
        }

        public void Deposit(IAccount account, IAmount amount)
        {
            account.Balance.Add(amount);
            account.StatementCollection.Add(_statementFactory.Create(new DateTime(), AccountAction.Deposit, amount, account.Balance));
        }
    }
}
