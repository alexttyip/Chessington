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
            if (board.GetPiece(oneSquareAhead) != null) {
                // Square ahead is occupied
                return output;
            }

            // Can move 1 square
            output.Add(oneSquareAhead);


            // Can move 2 squares if never moved
            if (hasMoved) return output;

            var twoSquaresAhead = Square.At(square.Row + 2 * playerSign, square.Col);

            // Two squares ahead is occupied
            if (board.GetPiece(twoSquaresAhead) != null) return output;

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