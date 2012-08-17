using System;

namespace eastward_gol
{
    public class World
    {
        readonly Cell[] cells;

        public World(Cell[] cells)
        {
            this.cells = cells;
        }

        public void Print(IPrinter printer)
        {
            var width = (int) Math.Sqrt(cells.Length);
            for (var i = 0; i < cells.Length;i++ )
            {
                printer.PrintCell(cells[i]);
                if ((i+1) % width == 0)
                {
                    printer.PrintNewLine();
                }
            }
        }
    }
}