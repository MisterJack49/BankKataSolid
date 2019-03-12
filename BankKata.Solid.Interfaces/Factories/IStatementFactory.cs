using BankKata.Solid.DI;
using BankKata.Solid.Interfaces.Model;
using System;

namespace BankKata.Solid.Interfaces.Factories
{
    [AbstractFactory]
    public interface IStatementFactory
    {
        IStatement Create(DateTime date, AccountAction accountAction, IAmount amount, IAmount balance);
    }
}
