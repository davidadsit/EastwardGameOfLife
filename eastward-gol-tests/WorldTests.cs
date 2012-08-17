using Moq;
using NUnit.Framework;
using eastward_gol;

namespace eastward_gol_tests
{
    [TestFixture]
    public class WorldTests
    {
        [Test]
        public void The_world_can_be_printed()
        {
            var cells = new[]
                {
                    Cell.Dead, Cell.Dead, Cell.Dead,
                    Cell.Dead, Cell.Dead, Cell.Dead,
                    Cell.Dead, Cell.Dead, Cell.Dead,
                };
            var world = new World(cells);
            var printer = new Mock<IPrinter>();
            world.Print(printer.Object);
            printer.Verify(x => x.PrintCell(cells[0]));
            printer.Verify(x => x.PrintCell(cells[1]));
            printer.Verify(x => x.PrintCell(cells[2]));
            printer.Verify(x => x.PrintCell(cells[3]));
            printer.Verify(x => x.PrintCell(cells[4]));
            printer.Verify(x => x.PrintCell(cells[5]));
            printer.Verify(x => x.PrintCell(cells[6]));
            printer.Verify(x => x.PrintCell(cells[7]));
            printer.Verify(x => x.PrintCell(cells[8]));
        }
        [Test]
        public void The_world_in_printed_as_a_grid()
        {
            var cells = new[]
                {
                    Cell.Dead, Cell.Dead, Cell.Dead,
                    Cell.Dead, Cell.Dead, Cell.Dead,
                    Cell.Dead, Cell.Dead, Cell.Dead,
                    Cell.Dead, Cell.Dead, Cell.Dead,
                    Cell.Dead, Cell.Dead, Cell.Dead,
                };
            var world = new World(cells);
            var printer = new Mock<IPrinter>();
            world.Print(printer.Object);
            printer.Verify(x => x.PrintNewLine(), Times.Exactly(5));
        }
    }
}