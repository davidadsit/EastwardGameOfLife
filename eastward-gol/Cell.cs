namespace eastward_gol
{
    public class Cell
    {
        readonly bool isAlive;

        Cell(bool isAlive)
        {
            this.isAlive = isAlive;
        }

        public static Cell Dead
        {
            get { return new Cell(false); }
        }

        public static Cell Living
        {
            get { return new Cell(true); }
        }

        public void Print(IPrinter printer)
        {
            var text = isAlive ? "0" : "-";
            printer.PrintString(text);
        }
    }
}