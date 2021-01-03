using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace Minesweeper.Tests
{
    public class CellSpec
    {
        [Theory, AutoData]
        public void SetBomb(Cell sut)
        {
            // Act
            sut.Click();
            sut.SetBomb();

            // Assert
            sut.ToString().Should().Be("*");
        }

        [Theory, AutoData]
        public void NearBombsCount(Cell sut)
        {
            // Act
            sut.Click();
            sut.NearBombsCount = 3;

            // Assert
            sut.ToString().Should().Be("3");
        }

        [Theory, AutoData]
        public void Covered(Cell sut)
        {
            // Assert
            sut.ToString().Should().Be(".");
        }

        [Theory, AutoData]
        public void RightClick(Cell sut)
        {
            // Act
            sut.RightClick();

            // Assert
            sut.ToString().Should().Be("A");
        }
    }
}
