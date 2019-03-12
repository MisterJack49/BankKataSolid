using BankKata.Solid.Interfaces;
using BankKata.Solid.Interfaces.Model;
using System;

namespace BankKata.Solid.Model
{
    public class Statement : IStatement
    {
        public Statement(DateTime date, AccountAction accountAction, IAmount amount, IAmount balance)
        {
            Date = date;
            AccountAction = accountAction;
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
            Balance = balance ?? throw new ArgumentNullException(nameof(balance));
        }

        public override string ToString() => $"| {Date.ToShortDateString()} | {DepositStatement} | {WithdrawalStatement} | {Balance.ToString()} |";

        private string DepositStatement => AccountAction == AccountAction.Deposit ? $"{Amount.ToString()}" : "";
        private string WithdrawalStatement => AccountAction == AccountAction.Withdrawal ? $"{Amount.ToString()}" : "";

        public DateTime Date { get; }
        public IAmount Balance { get; }
        public IAmount Amount { get; }
        public AccountAction AccountAction { get; }
    }
}
