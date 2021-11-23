using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var output = new List<Square>();
            var square = board.FindPiece(this);

            var longOffsets = new[] { -2, 2 };
            var shortOffsets = new[] { -1, 1 };

            var offsets = longOffsets.SelectMany(
                foo => shortOffsets,
                Tuple.Create
            ).ToList();

            output.AddRange(
                offsets.Select(tuple =>
                    Square.At(square.Row + tuple.Item1, square.Col + tuple.Item2)
                ).Where(fooSquare => IsKnightMoveLegal(fooSquare, board))
            );

            output.AddRange(
                offsets.Select(tuple =>
                    Square.At(square.Row + tuple.Item2, square.Col + tuple.Item1)
                ).Where(fooSquare => IsKnightMoveLegal(fooSquare, board))
            );

            return output;
        }

        private bool IsKnightMoveLegal(Square square, Board board)
        {
            if (!square.IsOnTheBoard()) return false;

            if (board.GetPiece(square) == null) return true;

            return board.GetPiece(square).Player != Player;
        }
    }
}