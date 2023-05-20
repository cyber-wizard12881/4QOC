using System;

namespace NQueensProblem
{
    public class Board
    {
        public Square[][] squares;

        public static int order = 1;
        public Board(int rows, int cols, string vacantSquare)
        {
            squares = new Square[rows][];

            for (int r = 0; r < cols; r++)
            {
                squares[r] = new Square[cols];
            }
            VacantSquare = vacantSquare;
            Init();
        }

        private void Init()
        {
            for (int r = 0; r < squares.Length; r++)
            {
                for (int c = 0; c < squares[r].Length; c++)
                {
                    squares[r][c] = new Square(VacantSquare);
                }
            }
        }

        public static string VacantSquare;

        public static void Print(Square[][] squares)
        {
            Console.WriteLine($"Solution {order++}: ");
            for (int r = 0; r < squares.Length; r++)
            {
                for (int c = 0; c < squares[r].Length; c++)
                {
                    Console.Write($"{squares[r][c].Value} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Solution {order++}: ");
            for (int r = 0; r < squares.Length; r++)
            {
                for (int c = 0; c < squares[r].Length; c++)
                {
                    Console.Write($"{squares[c][r].Value} ");
                }
                Console.WriteLine();
            }
        }
    }
}
