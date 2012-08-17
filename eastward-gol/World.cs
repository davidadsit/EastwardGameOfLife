using System;
using System.Collections.Generic;
using System.Linq;

namespace eastward_gol
{
    public class World
    {
        Cell[] cells;
        Cell[] nextGeneration;
        int? _width;

        public World(Cell[] cells)
        {
            this.cells = cells;
            nextGeneration = cells.Select(x => Cell.Dead).ToArray();
        }

        public void Print(IPrinter printer)
        {
            for (var i = 0; i < cells.Length; i++)
            {
                printer.PrintCell(i/Width, i%Width, cells[i]);
            }
        }

        int Width
        {
            get { return (int) (_width.HasValue ? _width.Value : _width = (int) Math.Sqrt(cells.Length)); }
        }

        public World Tick()
        {
            for (var row = 0; row < Width; row++)
            {
                for (var column = 0; column < Width; column++)
                {
                    var currentCell = cells[row*Width + column];
                    Neighborhood livingNeighbors = GetLivingNeighbors(row, column);

                    currentCell.AddToWorld(this, new Position(row, column), livingNeighbors);
                }
            }
            MoveGenerations();
            return this;
        }

        Neighborhood GetLivingNeighbors(int row, int column)
        {
            row = row - 1;
            column = column - 1;
            var neighbors = new Neighborhood();
            var cell = cells[row*Width + column];
            cell.AddIfLiving(neighbors);
            return neighbors;
        }

        void MoveGenerations()
        {
            cells = nextGeneration;
            nextGeneration = cells.Select(x => Cell.Dead).ToArray();
        }

        public void SetNextGeneration(Position position, Cell cell)
        {
            nextGeneration[position.Row*Width + position.Column] = cell;
        }
    }

    public struct Position
    {
        public readonly int Row;
        public readonly int Column;

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}