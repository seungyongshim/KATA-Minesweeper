using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace Minesweeper.Tests
{
    public class MineFieldSpec
    {
        [Fact]
        public void Construct()
        {
            // Arrange
            var sut = new MineField(4, 4);

            // Assert
            sut.Cells.Length.Should().Be(4 * 4);
        }

        [Theory]
        [InlineAutoData]
        [InlineAutoData]
        [InlineAutoData]
        [InlineAutoData]
        [InlineAutoData]
        public void SetBombs([Range(3, 5)] int bombCount)
        {
            // Arrange
            var sut = new MineField(4, 4, bombCount);

            // Act
            sut.SetBombs();

            // Assert
            sut.Cells.Where(x => x.IsBomb).Count().Should().Be(bombCount);
        }

        [Fact]
        public void SetNearBombsCounts()
        {
            // Arrange
            var sut = new MineField(4, 4);

            // Act
            sut.Cells[1].SetBomb();
            sut.SetNearBombsCounts();

            // 1 * 1 0
            // 1 1 1 0
            // 0 0 0 0 
            // 0 0 0 0
            // Assert

            sut.Cells.Select(x => x.NearBombsCount)
                     .Should()
                     .BeEquivalentTo(new[] { 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        }

        [Fact]
        public void GetNearCells()
        {
            // Arrange
            var sut = new MineField(4, 4);

            // Act
            var ret = sut.GetNearCells(0, 0);

            // Assert
            ret.Should()
               .BeEquivalentTo(new[]
               { sut.Cells[1],
                 sut.Cells[4],
                 sut.Cells[5],
               });
        }
    }
}
