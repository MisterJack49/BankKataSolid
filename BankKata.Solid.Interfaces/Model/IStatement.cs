using System;

namespace BankKata.Solid.Interfaces.Model
{
    public interface IStatement
    {
        string ToString();

        DateTime Date { get; }
        IAmount Balance { get; }
        IAmount Amount { get; }
        AccountAction AccountAction { get; }
    }
}
