using System;

namespace NQueensProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = 8;
            int turns = 0;
            var board = new Board(N, N, ".");
            var solver = new Solver(new Piece("Q"));
            for (int row = 0; row < N; row++)
            {
                solver.Solve(board.squares, row, turns);
                board = new Board(N, N, ".");
                turns = 0;
            }
            Console.ReadKey();
        }
    }
}
