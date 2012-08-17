using System.Collections.Generic;
using Moq;
using Moq.Language.Flow;
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
            printer.Verify(x => x.PrintCell(0, 0, cells[0]));
            printer.Verify(x => x.PrintCell(0, 1, cells[1]));
            printer.Verify(x => x.PrintCell(0, 2, cells[2]));
            printer.Verify(x => x.PrintCell(1, 0, cells[3]));
            printer.Verify(x => x.PrintCell(1, 1, cells[4]));
            printer.Verify(x => x.PrintCell(1, 2, cells[5]));
            printer.Verify(x => x.PrintCell(2, 0, cells[6]));
            printer.Verify(x => x.PrintCell(2, 1, cells[7]));
            printer.Verify(x => x.PrintCell(2, 2, cells[8]));
        }
       [Test]
        public void The_world_can_be_printed_as_a_unit()
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
            printer.Verify(x => x.PrintCell(0, 0, cells[0]));
            printer.Verify(x => x.PrintCell(0, 1, cells[1]));
            printer.Verify(x => x.PrintCell(0, 2, cells[2]));
            printer.Verify(x => x.PrintCell(1, 0, cells[3]));
            printer.Verify(x => x.PrintCell(1, 1, cells[4]));
            printer.Verify(x => x.PrintCell(1, 2, cells[5]));
            printer.Verify(x => x.PrintCell(2, 0, cells[6]));
            printer.Verify(x => x.PrintCell(2, 1, cells[7]));
            printer.Verify(x => x.PrintCell(2, 2, cells[8]));
        }

        [Test]
        public void When_ticked_the_world_is_the_same_world()
        {
            var world = new World(new Cell[] {});
            var newWorld = world.Tick();
            Assert.AreEqual(world, newWorld);
        }

        [Test]
        public void When_ticked_the_world_kills_an_isolated_living_cell()
        {
            var cells = new[]
                {
                    Cell.Dead, Cell.Dead, Cell.Dead,
                    Cell.Dead, Cell.Alive, Cell.Dead,
                    Cell.Dead, Cell.Dead, Cell.Dead,
                };

            var world = new World(cells);
            var newWorld = world.Tick();
            var printer = new Mock<IPrinter>();
            newWorld.Print(printer.Object);
            printer.Verify(x => x.PrintCell(0, 0, Cell.Dead));
            printer.Verify(x => x.PrintCell(0, 1, Cell.Dead));
            printer.Verify(x => x.PrintCell(0, 2, Cell.Dead));
            printer.Verify(x => x.PrintCell(1, 0, Cell.Dead));
            printer.Verify(x => x.PrintCell(1, 1, Cell.Dead));
            printer.Verify(x => x.PrintCell(1, 2, Cell.Dead));
            printer.Verify(x => x.PrintCell(2, 0, Cell.Dead));
            printer.Verify(x => x.PrintCell(2, 1, Cell.Dead));
            printer.Verify(x => x.PrintCell(2, 2, Cell.Dead));
        }

        [Test]
        public void When_ticked_the_world_kills_a_lonely_living_cell()
        {
            var cells = new[]
                {
                    Cell.Dead, Cell.Dead, Cell.Dead,
                    Cell.Dead, Cell.Alive, Cell.Alive,
                    Cell.Dead, Cell.Dead, Cell.Dead,
                };

            var world = new World(cells);
            var newWorld = world.Tick();
            var printer = new Mock<IPrinter>();
            newWorld.Print(printer.Object);
            printer.Verify(x => x.PrintCell(0, 0, Cell.Dead));
            printer.Verify(x => x.PrintCell(0, 1, Cell.Dead));
            printer.Verify(x => x.PrintCell(0, 2, Cell.Dead));
            printer.Verify(x => x.PrintCell(1, 0, Cell.Dead));
            printer.Verify(x => x.PrintCell(1, 1, Cell.Dead));
            printer.Verify(x => x.PrintCell(1, 2, Cell.Dead));
            printer.Verify(x => x.PrintCell(2, 0, Cell.Dead));
            printer.Verify(x => x.PrintCell(2, 1, Cell.Dead));
            printer.Verify(x => x.PrintCell(2, 2, Cell.Dead));
        }

        [Test]
        public void When_ticked_the_world_makes_the_block_happen()
        {
            var cells = new[]
                {
                    Cell.Dead, Cell.Alive, Cell.Alive,
                    Cell.Dead, Cell.Alive, Cell.Alive,
                    Cell.Dead, Cell.Dead, Cell.Dead,
                };

            var world = new World(cells);
            var newWorld = world.Tick();
            var printer = new Mock<IPrinter>();
            newWorld.Print(printer.Object);
            printer.Verify(x => x.PrintCell(0, 0, Cell.Dead));
            printer.Verify(x => x.PrintCell(0, 1, Cell.Alive));
            printer.Verify(x => x.PrintCell(0, 2, Cell.Alive));
            printer.Verify(x => x.PrintCell(1, 0, Cell.Alive));
            printer.Verify(x => x.PrintCell(1, 1, Cell.Alive));
            printer.Verify(x => x.PrintCell(1, 2, Cell.Dead));
            printer.Verify(x => x.PrintCell(2, 0, Cell.Dead));
            printer.Verify(x => x.PrintCell(2, 1, Cell.Dead));
            printer.Verify(x => x.PrintCell(2, 2, Cell.Dead));
        }                                    

        [Test]
        [Ignore("This is way too much for the next step")]
        public void When_ticked_the_world_makes_the_blinker_happen()
        {
            var cells = new[]
                {
                    Cell.Dead, Cell.Dead, Cell.Dead,
                    Cell.Alive, Cell.Alive, Cell.Alive,
                    Cell.Dead, Cell.Dead, Cell.Dead,
                };

            var world = new World(cells);
            var newWorld = world.Tick();
            var printer = new Mock<IPrinter>();
            newWorld.Print(printer.Object);
            printer.Verify(x => x.PrintCell(0, 0, Cell.Dead));
            printer.Verify(x => x.PrintCell(0, 1, Cell.Alive));
            printer.Verify(x => x.PrintCell(0, 2, Cell.Dead));
            printer.Verify(x => x.PrintCell(1, 0, Cell.Dead));
            printer.Verify(x => x.PrintCell(1, 1, Cell.Alive));
            printer.Verify(x => x.PrintCell(1, 2, Cell.Dead));
            printer.Verify(x => x.PrintCell(2, 0, Cell.Dead));
            printer.Verify(x => x.PrintCell(2, 1, Cell.Alive));
            printer.Verify(x => x.PrintCell(2, 2, Cell.Dead));
        }
    }

    public static class MoqExtensions
    {
        public static void ReturnsInOrder<T, TResult>(this ISetup<T, TResult> setup,
                                       params TResult[] results) where T : class
        {
            setup.Returns(new Queue<TResult>(results).Dequeue);
        }   
    }
}