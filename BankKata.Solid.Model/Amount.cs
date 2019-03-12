using BankKata.Solid.Interfaces.Model;

namespace BankKata.Solid.Model
{
    public class Amount : IAmount
    {
        private int _money;

        public Amount(int money)
        {
            _money = money;
        }

        public int Value => _money;

        public override string ToString() => _money.ToString("C");

        public void Add(IAmount amount) => _money += amount.Value;
        public void Substract(IAmount amount) => _money -= amount.Value;
    }
}
