using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [Fact]
        public void SetBombs()
        {
            // Arrange
            var sut = new MineField(4, 4, 3);

            // Act
            sut.SetBombs();

            // Assert
            sut.Cells.Where(x => x.IsBomb).Count().Should().Be(3);
        }
    }
}
