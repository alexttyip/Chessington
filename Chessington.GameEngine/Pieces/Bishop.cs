using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var square = board.FindPiece(this);

            // Really poor name
            var vectors = new[] { -1, 1 };

            var directions = vectors
                .SelectMany(foo => vectors, Tuple.Create);

            return GetAvailableMovesWithDirection(square, board, directions);
        }
    }
}