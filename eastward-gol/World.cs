using System;
using System.Linq;

namespace eastward_gol
{
    public class World
    {
        Cell[] cells;

        public World(Cell[] cells)
        {
            this.cells = cells;
        }

        public void Print(IPrinter printer)
        {
            var width = (int) Math.Sqrt(cells.Length);
            for (var i = 0; i < cells.Length; i++)
            {
                printer.PrintCell(i/width, i%width, cells[i]);
            }
        }

        public World Tick()
        {
            cells = cells.Select(x => Cell.Dead).ToArray();

            return this;
        }
    }
}