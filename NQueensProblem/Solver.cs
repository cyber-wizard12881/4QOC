namespace NQueensProblem
{
    public class Solver
    {
        public Piece Piece;

        public Solver(Piece piece)
        {
            Piece = piece;
        }
        public bool Solve(Square[][] board, int row, int turns)
        {
            if (turns == board.Length) //if the entire rows have been traversed
            {
                Board.Print(board); //print the solution
                return true; //true as the solution was found!
            }
            for (int c = 0; c < board.Length; c++) //iterate over the columns row-wise (i.e. row-by-row)
            {
                //Check if all the Constraints are Satisfied or not?
                if (Piece.Place(board, row % board.Length, c)) //if the Queen can be placed, then place it on the board!
                {
                    board[row % board.Length][c].Value = Piece.Name; //Place the Piece on the Board!
                    if(Solve(board, row%board.Length + 1, turns + 1)) //recursively call the solver to place the other Queens!
                        return true; //One Solution is found and Complete!
                    board[row % board.Length][c].Value = Board.VacantSquare; //If not success, here, remove the Piece from the Board! (Mark it as vacant!)
                }
            }
            return false; //false if queens cannot be placed anymore! Hit a Dead-End!
        }
    }
}
