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

        public static Cell Alive
        {
            get { return new Cell(true); }
        }

        public void Print(int row, int column, IPrinter printer)
        {
            var text = isAlive ? "0" : "-";
            printer.PrintString(row, column, text);
        }

        public bool Equals(Cell other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.isAlive.Equals(isAlive);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Cell)) return false;
            return Equals((Cell) obj);
        }

        public override int GetHashCode()
        {
            return isAlive.GetHashCode();
        }

        public static bool operator ==(Cell left, Cell right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Cell left, Cell right)
        {
            return !Equals(left, right);
        }
    }
}