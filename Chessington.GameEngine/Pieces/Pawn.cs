using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private bool hasMoved;
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var square = board.FindPiece(this);
            var playerSign = Player == Player.White ? -1 : 1;

            var output = GetAvailableForwardMoves(square, board, playerSign).ToList();
            
            foreach(var i in new[]{-1, 1}) {
                var targetSquare = Square.At(square.Row + 1 * playerSign, square.Col + i);
                
                if (!targetSquare.IsOnTheBoard()) continue;

                var targetPiece = board.GetPiece(targetSquare);
                
                if (targetPiece == null) continue;
                
                if (targetPiece.Player == Player) continue;

                output.Add(targetSquare);
            }

            return output;
        }

        private IEnumerable<Square> GetAvailableForwardMoves(Square square, Board board, int playerSign)
        {
            var output = new List<Square>();
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