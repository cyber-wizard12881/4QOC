using System;

namespace EditDistance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] s = new[] { null, "L", "O", "N", "D", "O", "N", null };
            string[] t = new[] { null, "B", "O", "S", "T", "O", "N", null };
            var ed = new EditDistance(s, t);
            ed.Solve();
            s = new[] { null, "S", "A", "N", "F", "R", "A", "N", "C", "I", "S", "C", "O", null };
            t = new[] { null, "B", "O", "S", "T", "O", "N", null };
            ed = new EditDistance(s, t);
            ed.Solve();
            s = new[] { null, "K", "I", "T", "T", "E", "N", null };
            t = new[] { null, "S", "I", "T", "T", "I", "N", "G", null };
            ed = new EditDistance(s, t);
            ed.Solve();
            Console.ReadKey();
        }
    }
}
