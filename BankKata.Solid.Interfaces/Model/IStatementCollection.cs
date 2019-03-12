using System.Collections.Generic;

namespace BankKata.Solid.Interfaces.Model
{
    public interface IStatementCollection
    {
        void Add(IStatement statement);
        IEnumerable<IStatement> Statements { get; }
    }
}
