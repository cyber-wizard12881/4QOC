namespace EditDistance
{
    internal class Table
    {
        public int i;
        public int j;
        public Cell[][] cells;
        public Table(string[] s, string[] t)
        {
            i = s.Length;
            j = t.Length;
            cells = new Cell[i][];
            for (int k = 0; k < i; k++)
            {
                cells[k] = new Cell[j];
            }

            for (int l = 0; l < i; l++)
                for (int m = 0; m < j; m++)
                {
                    cells[l][m] = new Cell(l, m);
                    if(l == 0 &&  m!=0)//!string.IsNullOrEmpty(t[m]))
                    {
                        cells[l][m].operation = $"Create {t[m]}";
                        cells[l][m].opCounts = 1;
                        cells[l][m].row = l;
                        cells[l][m].col = m - 1;
                    }
                    if(m == 0 && l!= 0 )//!string.IsNullOrEmpty(s[l]))
                    {
                        cells[l][m].operation = $"Drop {s[l]}";
                        cells[l][m].opCounts = 1;
                        cells[l][m].row = l - 1;
                        cells[l][m].col = m;
                    }
                }
        }

    }
}
