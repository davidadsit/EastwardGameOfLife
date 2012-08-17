using System;
using eastward_gol;

namespace gol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            var cells = new[]
                    {
                        Cell.Dead, Cell.Dead, Cell.Dead,
                        Cell.Dead, Cell.Alive, Cell.Dead,
                        Cell.Dead, Cell.Dead, Cell.Dead,
                    };
            var world = new World(cells);
            do
            {
                world.Print(new ConsolePrinter());
                world.Tick();
                key = Console.ReadKey();

            } while (key.Key != ConsoleKey.Q);
        }
    }
}