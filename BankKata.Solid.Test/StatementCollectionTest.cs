using AutoFixture;
using BankKata.Solid.Interfaces.Model;
using BankKata.Solid.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BankKata.Solid.Tests
{
    public class StatementCollectionTest
    {
        [Fact]
        public void ShouldThrowIfNoListIsPassed()
        {
            Action act = () => new StatementCollection(null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Theory, AutoMoqData]
        public void ShouldSetCollection(IEnumerable<IStatement> statements)
        {
            var sut = new StatementCollection(statements);

            sut.Statements.Should().NotBeNullOrEmpty().And.HaveCount(statements.Count());
        }

        [Theory, AutoMoqData]
        public void ShouldAddToCollection(IFixture fixture)
        {
            var sut = new StatementCollection(new List<IStatement>());
            sut.Add(fixture.Create<IStatement>());

            sut.Statements.Should().HaveCount(1);
        }
    }
}
