using BankKata.Solid.Interfaces.Model;

namespace BankKata.Solid.Interfaces.Services
{
    public interface IAccountService
    {
        IAccount CreateAccount();
        void Deposit(IAccount account, IAmount amount);
    }
}
