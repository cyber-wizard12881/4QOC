namespace NQueensProblem
{
    public class Piece : AttackVector
    {
        public string Name;
        public Piece(string name)
        {
            Name = name;
        }

        public override bool Place(Square[][] board, int row, int col)
        {
            //file wise
            for (int r = 0; r < board.Length; r++)
            {
                if (r == row)
                    continue;
                if (board[r][col].Value == Name)
                    return false;
            }
            //rank wise
            for (int c = 0; c < board.Length; c++)
            {
                if (c == col)
                    continue;
                if (board[row][c].Value == Name)
                    return false;
            }
            //NW Diagonal
            for (int r = row, c = col; r >= 0 && c >= 0; r--, c--)
            {
                if (!board.WithinBounds(r, c))
                    continue;
                if (board.WithinBounds(r, c) && board[r][c].Value == Name)
                    return false;
            }
            //SE Diagonal
            for (int r = row, c = col; r < board.Length && c < board.Length; r++, c++)
            {
                if (!board.WithinBounds(r, c))
                    continue;
                if (board.WithinBounds(r, c) && board[r][c].Value == Name)
                    return false;
            }
            //SW Diagonal
            for (int r = row, c = col; r < board.Length && c >= 0; r++, c--)
            {
                if (!board.WithinBounds(r, c))
                    return false;
                if (board.WithinBounds(r, c) && board[r][c].Value == Name)
                    return false;
            }
            //NE Diagonal
            for (int r = row, c = col; r >= 0 && c < board.Length; r--, c++)
            {
                if (!board.WithinBounds(r, c))
                    return false;
                if (board.WithinBounds(r, c) && board[r][c].Value == Name)
                    return false;
            }
            return true;
        }
    }
}
