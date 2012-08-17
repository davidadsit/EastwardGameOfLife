using System;
using eastward_gol;

namespace gol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cells = new[]
                {
                    Cell.Dead, Cell.Dead, Cell.Dead,
                    Cell.Dead, Cell.Living, Cell.Dead,
                    Cell.Dead, Cell.Dead, Cell.Dead,
                };
            var world = new World(cells);
            world.Print(new ConsolePrinter());
            Console.ReadKey();
        }
    }
}