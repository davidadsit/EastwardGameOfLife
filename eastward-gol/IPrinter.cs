namespace eastward_gol
{
    public interface IPrinter
    {
        void PrintCell(Cell cell);
        void PrintString(string text);
        void PrintNewLine();
    }
}