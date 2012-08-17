namespace eastward_gol
{
    public interface IPrinter
    {
        void PrintCell(int row, int column, Cell cell);
        void PrintString(int row, int column, string text);
    }
}