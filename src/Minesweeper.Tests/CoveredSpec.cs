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
    public class CoveredSpec
    {
        [Theory, AutoData]
        public void Click([Frozen]Cell cell, Covered sut)
        {
            // Act
            sut.Click();

            // Assert
            cell.CoverState.Should().BeOfType<Uncovered>();
        }
    }
}