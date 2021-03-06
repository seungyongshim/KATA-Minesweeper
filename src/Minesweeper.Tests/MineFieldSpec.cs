using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

            // Assert
            sut.Cells.Where(x => x.IsBomb).Count().Should().Be(bombCount);
        }

        [Fact]
        public void SetBombsWithoutRandomize()
        {
            // Arrange
            var indices = new[] { 1, 3, 8 };
            var sut = new MineField(4, 4, indices);

            // Assert
            (from i in indices
             let c = sut.Cells[i].IsBomb
             where c is not true
             select c).Should().BeEmpty();
        }

        [Fact]
        public void SetNearBombsCounts()
        {
            // Arrange
            var sut = new MineField(2, 3, new[] { 1 });

            // 1 *
            // 1 1
            // 0 0
            // Assert

            sut.Cells.Select(x => x.NearBombsCount)
                     .Should()
                     .BeEquivalentTo(new[] { 1, 0, 1, 1, 0, 0 });
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

        [Fact]
        public void Click()
        {
            // Arrange
            var sut = new MineField(3, 3, new[] { 0 });

            // Act
            sut.Click(2, 2);

            // . 1 0
            // 1 1 0
            // 0 0 0

            // Assert
            sut.ToString().Should().Be(".10110000");
        }
    }
}
