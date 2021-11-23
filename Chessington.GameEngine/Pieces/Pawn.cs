using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private bool hasMoved;
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var output = new List<Square>();
            var square = board.FindPiece(this);

            var playerSign = Player == Player.White ? -1 : 1;

            var oneSquareAhead = Square.At(square.Row + 1 * playerSign, square.Col);
            if (!oneSquareAhead.IsOnTheBoard() || board.IsOccupied(oneSquareAhead)) {
                // Square ahead is occupied
                return output;
            }

            // Can move 1 square
            output.Add(oneSquareAhead);

            var twoSquaresAhead = Square.At(square.Row + 2 * playerSign, square.Col);

            // Can move 2 squares if never moved
            if (!twoSquaresAhead.IsOnTheBoard() || hasMoved) return output;

            // Two squares ahead is occupied
            if (board.IsOccupied(twoSquaresAhead)) return output;

            output.Add(twoSquaresAhead);

            return output;
        }

        public override void MoveTo(Board board, Square newSquare)
        {
            base.MoveTo(board, newSquare);
            hasMoved = true;
        }
    }
}