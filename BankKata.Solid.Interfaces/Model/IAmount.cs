namespace BankKata.Solid.Interfaces.Model
{
    public interface IAmount
    {
        int Value { get; }
        void Add(IAmount amount);
        void Substract(IAmount amount);
        string ToString();
    }
}
