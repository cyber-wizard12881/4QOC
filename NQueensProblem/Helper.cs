namespace NQueensProblem
{
    public static class Helper
    {
        public static bool WithinBounds(this Square[][] squares, int row, int col)
        {
            return row >= 0 && row < squares.Length && col >= 0 && col < squares.Length;
        }
    }
}
