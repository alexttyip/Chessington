using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var square = board.FindPiece(this);

            // Really poor name
            var vectors = new[] { -1, 0, 1 };

            var directions = vectors
                .SelectMany(foo => vectors, Tuple.Create)
                .Where(tuple => {
                    if (tuple.Item1 != 0 && tuple.Item2 != 0) return false;

                    return tuple.Item1 != 0 || tuple.Item2 != 0;
                });

            return GetAvailableMovesWithDirection(square, board, directions);
        }
    }
}