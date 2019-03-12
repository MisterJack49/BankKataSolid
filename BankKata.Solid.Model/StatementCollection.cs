using BankKata.Solid.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankKata.Solid.Model
{
    public class StatementCollection : IStatementCollection
    {
        private List<IStatement> _statements = new List<IStatement>();

        public StatementCollection(IEnumerable<IStatement> statements)
        {
            _statements = statements?.ToList() ?? throw new ArgumentNullException(nameof(statements));
        }

        public void Add(IStatement statement)
        {
            _statements.Add(statement);
        }

        public IEnumerable<IStatement> Statements => _statements;
    }
}
