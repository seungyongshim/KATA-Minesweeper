using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace Minesweeper.Tests
{
    public class FlagedSpec
    {
        [Theory, AutoData]
        public void Click([Frozen] Cell cell, Flaged sut)
        {
            // Act
            sut.Click();

            // Assert
            cell.CoverState.Should().BeOfType<Flaged>();
        }
        [Theory, AutoData]
        public void RightClick([Frozen] Cell cell, Flaged sut)
        {
            // Act
            sut.RightClick();

            // Assert
            cell.CoverState.Should().BeOfType<Covered>();
        }
        [Theory, AutoData]
        public void ReturnToString([Frozen] Cell cell, Flaged sut)
        {
            // Assert
            sut.ToString().Should().Be("A");
        }
    }
}
