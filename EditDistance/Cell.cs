namespace EditDistance
{
    internal class Cell
    {
        public int row;
        public int col;
        public int opCounts;
        public string operation;
        public Cell(int row, int col)
        {
            this.row = row;
            this.col = col;
            opCounts = 0;
            operation = null;
        }
    }
}
