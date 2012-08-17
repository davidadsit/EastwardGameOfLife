using System;
using eastward_gol;

namespace gol
{
    internal class ConsolePrinter : IPrinter
    {
        public void PrintCell(int row, int column, Cell cell)
        {
            cell.Print(row, column, this);
        }

        public void PrintString(int row, int column, string text)
        {
            Console.CursorLeft = column*2;
            Console.CursorTop = row;
            Console.Out.Write(" {0}", text);
        }
    }
}