using System;
using System.Collections.Generic;
using System.Linq;

namespace EditDistance
{
    internal class EditDistance
    {
        public string[] s;
        public string[] t;
        public Table table;
        public EditDistance(string[] s, string[] t)
        {
            this.s = s;
            this.t = t;
            table = new Table(s, t);
        }

        public void Solve()
        {
            Build(table);
            var results = Compute(table, s.Length - 1, t.Length - 1).ToList();
            Print(results);
        }

        public void Build(Table table)
        {
            for (int i = 1; i < table.i; i++)
            {
                for (int j = 1; j < table.j; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        table.cells[i][j].row = i - 1;
                        table.cells[i][j].col = j - 1;
                        table.cells[i][j].opCounts = table.cells[i - 1][j - 1].opCounts; // From i-1,j-1 with no changes or operations!!
                        if (t[j - 1] != null)
                            table.cells[i][j].operation = $"Copy {s[i - 1]} --> {t[j - 1]}";
                        else
                            table.cells[i][j].operation = string.Empty;
                        continue;
                    }

                    if (table.cells[i][j - 1].opCounts + 1 <= table.cells[i - 1][j - 1].opCounts && table.cells[i][j - 1].opCounts + 1 <= table.cells[i - 1][j].opCounts)
                    {
                        table.cells[i][j].row = i;
                        table.cells[i][j].col = j - 1;
                        table.cells[i][j].opCounts = table.cells[i][j - 1].opCounts + 1; // From i,j-1 with Create as the operation!!
                        if (t[j - 1] != null)
                            table.cells[i][j].operation = $"Create {t[j - 1]}";
                        else
                            table.cells[i][j].operation = string.Empty;
                        continue;
                    }

                    if (table.cells[i - 1][j].opCounts + 1 <= table.cells[i - 1][j - 1].opCounts && table.cells[i - 1][j].opCounts + 1 <= table.cells[i][j - 1].opCounts)
                    {
                        table.cells[i][j].row = i - 1;
                        table.cells[i][j].col = j;
                        table.cells[i][j].opCounts = table.cells[i - 1][j].opCounts + 1; // From i-1,j with Drop as the operation!!
                        if (s[i - 1] != null)
                            table.cells[i][j].operation = $"Drop {s[i - 1]}";
                        else
                            table.cells[i][j].operation = string.Empty;

                        continue;
                    }

                    if (table.cells[i - 1][j - 1].opCounts <= table.cells[i][j - 1].opCounts && table.cells[i - 1][j - 1].opCounts <= table.cells[i - 1][j].opCounts)
                    {
                        table.cells[i][j].row = i - 1;
                        table.cells[i][j].col = j - 1;
                        table.cells[i][j].opCounts = table.cells[i - 1][j - 1].opCounts; // From i-1,j-1 with changes as Replace being the operation!!
                        if (t[j - 1] != null)
                            table.cells[i][j].operation = $"Replace {s[i - 1]} --> {t[j - 1]}";
                        else
                            table.cells[i][j].operation = string.Empty;
                        continue;
                    }
                }
            }
        }

        public IEnumerable<string> Compute(Table table, int i, int j)
        {
            IEnumerable<string> results = new List<string>();
            int m = i;
            int n = j;
            do
            {
                results = results.Prepend(table.cells[m][n].operation);
                m = table.cells[m][n].row;
                n = table.cells[m][n].col;
            }
            while (table.cells[m][n].operation != null);
            return results.Where(r => !string.IsNullOrEmpty(r));
        }

        public void Print(List<string> results)
        {
            Console.WriteLine($"Total Operations: {results.Count}");
            results.ForEach(r =>
            {
                Console.WriteLine(r);
            });
        }
    }
}
