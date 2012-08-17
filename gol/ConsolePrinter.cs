using System;
using eastward_gol;

namespace gol
{
    internal class ConsolePrinter : IPrinter
    {
        public void PrintCell(Cell cell)
        {
            cell.Print(this);
        }

        public void PrintString(string text)
        {
            Console.Out.Write(" {0}", text);
        }

        public void PrintNewLine()
        {
            Console.Out.WriteLine("");
        }
    }
}