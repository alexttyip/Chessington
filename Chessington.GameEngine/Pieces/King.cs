using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var square = board.FindPiece(this);

            var moves = new[] { -1, 0, 1 };

            return moves
                .SelectMany(foo => moves,
                    (i, j) => Square.At(square.Row + i, square.Col + j)
                )
                .Where(s => {
                    if (s == square || !s.IsOnTheBoard()) return false;

                    var pieceAtDestSquare = board.GetPiece(s);

                    if (pieceAtDestSquare == null) return true;

                    return pieceAtDestSquare.Player != Player;
                });
        }
    }
}