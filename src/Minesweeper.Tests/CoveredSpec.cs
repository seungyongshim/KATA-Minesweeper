using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace Minesweeper.Tests
{
    public class CoveredSpec
    {
        [Theory, AutoData]
        public void Click([Frozen] Cell cell, Covered sut)
        {
            // Act
            sut.Click();

            // Assert
            cell.CoverState.Should().BeOfType<Uncovered>();
        }

        [Theory, AutoData]
        public void RightClick([Frozen] Cell cell, Covered sut)
        {
            // Act
            sut.RightClick();

            // Assert
            cell.CoverState.Should().BeOfType<Flaged>();
        }

        [Theory, AutoData]
        public void ReturnToString(Covered sut)
        {
            // Assert
            sut.ToString().Should().Be(".");
        }
    }
}
