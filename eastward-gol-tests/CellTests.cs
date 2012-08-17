using Moq;
using NUnit.Framework;
using eastward_gol;

namespace eastward_gol_tests
{
    [TestFixture]
    public class CellTests
    {
        [Test]
        public void A_dead_cell_prints_a_dash()
        {
            var cell = Cell.Dead;
            var printer = new Mock<IPrinter>();
            cell.Print(It.IsAny<int>(), It.IsAny<int>(), printer.Object);
            printer.Verify(x=>x.PrintString(It.IsAny<int>(), It.IsAny<int>(), "-"));
        }    
        
        [Test]
        public void A_living_cell_prints_a_zero()
        {
            var cell = Cell.Alive;
            var printer = new Mock<IPrinter>();
            cell.Print(It.IsAny<int>(), It.IsAny<int>(), printer.Object);
            printer.Verify(x => x.PrintString(It.IsAny<int>(), It.IsAny<int>(), "0"));
        }

        [Test]
        public void Any_dead_cell_is_equal_to_any_other_dead_cell()
        {
           Assert.AreEqual(Cell.Dead, Cell.Dead);
        }

        [Test]
        public void Any_living_cell_is_equal_to_any_other_living_cell()
        {
           Assert.AreEqual(Cell.Alive, Cell.Alive);
        }
    }
}