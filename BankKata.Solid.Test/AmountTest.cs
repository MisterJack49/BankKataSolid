using BankKata.Solid.Model;
using FluentAssertions;
using Xunit;

namespace BankKata.Solid.Tests
{
    public class AmountTest
    {
        [Theory, AutoMoqData]
        public void ShouldSetAmount(int value)
        {
            var sut = new Amount(value);
            sut.Value.Should().Be(value);
        }

        [Theory, AutoMoqData]
        public void ShouldGetCurrencyValue(int value)
        {
            var sut = new Amount(value);
            sut.ToString().Should().Be(value.ToString("C"));
        }

        [Theory, AutoMoqData]
        public void ShouldAddAmount(Amount sut, Amount b)
        {
            var test = sut.Value + b.Value;
            sut.Add(b);
            sut.Value.Should().Be(test);
        }
    }
}
