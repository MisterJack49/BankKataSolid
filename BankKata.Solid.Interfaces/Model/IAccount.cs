namespace BankKata.Solid.Interfaces.Model
{
    public interface IAccount
    {
        IAmount Balance { get; }
        IStatementCollection StatementCollection { get; }
    }
}
