using BankKata.Solid.DI;
using BankKata.Solid.Interfaces.Model;
using System.Collections.Generic;

namespace BankKata.Solid.Interfaces.Factories
{
    [AbstractFactory]
    public interface IStatementCollectionFactory
    {
        IStatementCollection Create(IEnumerable<IStatement> statements);
    }
}
