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
            cell.Print(printer.Object);
            printer.Verify(x=>x.PrintString("-"));
        }    
        
        [Test]
        public void A_living_cell_prints_a_zero()
        {
            var cell = Cell.Living;
            var printer = new Mock<IPrinter>();
            cell.Print(printer.Object);
            printer.Verify(x=>x.PrintString("0"));
        }
    }
}