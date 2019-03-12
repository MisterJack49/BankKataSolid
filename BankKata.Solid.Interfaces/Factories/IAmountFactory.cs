using BankKata.Solid.DI;
using BankKata.Solid.Interfaces.Model;

namespace BankKata.Solid.Interfaces.Factories
{
    [AbstractFactory]
    public interface IAmountFactory
    {
        IAmount Create(int money);
    }
}
