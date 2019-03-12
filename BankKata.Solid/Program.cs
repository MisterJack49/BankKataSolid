using BankKata.Solid.Interfaces.Factories;
using BankKata.Solid.Interfaces.Services;
using Ninject;
using System;
using System.Linq;

namespace BankKata.Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var kernel = new StandardKernel(new CompositionRoot());

            var accountService = kernel.Get<IAccountService>();
            var account = accountService.CreateAccount();

            Console.WriteLine(account.Balance.ToString());

            var amountFactory = kernel.Get<IAmountFactory>();
            accountService.Deposit(account, amountFactory.Create(100));
            //accountService.Withdraw(account, amountFactory.Create(45));

            account.StatementCollection
                .Statements
                .OrderByDescending(x => x.Date)
                .Iter(statement => Console.WriteLine(statement.ToString()));

            Console.ReadLine();
        }
    }
}
