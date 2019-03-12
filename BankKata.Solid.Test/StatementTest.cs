using BankKata.Solid.Interfaces;
using BankKata.Solid.Interfaces.Model;
using BankKata.Solid.Model;
using FluentAssertions;
using System;
using Xunit;

namespace BankKata.Solid.Tests
{
    public class StatementTest
    {
        [Theory, AutoMoqData]
        public void ShouldThrowIfStatementAmountIsNull(DateTime date, AccountAction action, IAmount balance)
        {
            Action sut = () => new Statement(date, action, null, balance);
            sut.Should().Throw<ArgumentNullException>();
        }

        [Theory, AutoMoqData]
        public void ShouldThrowIfStatementBalanceIsNull(DateTime date, AccountAction action, IAmount amount)
        {
            Action sut = () => new Statement(date, action, amount, null);
            sut.Should().Throw<ArgumentNullException>();
        }

        [Theory, AutoMoqData]
        public void ShouldReturnFormattedStringWithDeposit(DateTime date, IAmount balance, IAmount amount)
        {
            var sut = new Statement(date, AccountAction.Deposit, amount, balance);

            var assert = $"| {date.ToShortDateString()} | {amount.ToString()} |  | {balance.ToString()} |";
            sut.ToString().Should().Be(assert);
        }

        [Theory, AutoMoqData]
        public void ShouldReturnFormattedStringWithWithdrawal(DateTime date, IAmount balance, IAmount amount)
        {
            var sut = new Statement(date, AccountAction.Withdrawal, amount, balance);

            var assert = $"| {date.ToShortDateString()} |  | {amount.ToString()} | {balance.ToString()} |";
            sut.ToString().Should().Be(assert);
        }
    }
}
