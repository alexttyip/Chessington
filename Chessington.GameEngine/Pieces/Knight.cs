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

            var signs = new[] { -1, 1 };
            var signPairs = signs.SelectMany(foo => signs, Tuple.Create);
            var magnitudes = new[] { Tuple.Create(1, 2), Tuple.Create(2, 1) };

            var offsets = signPairs.SelectMany(
                foo => magnitudes,
                (sign, magnitude) =>
                    Tuple.Create(sign.Item1 * magnitude.Item1, sign.Item2 * magnitude.Item2)
            ).ToList();

            output.AddRange(
                offsets.Select(tuple =>
                    Square.At(square.Row + tuple.Item1, square.Col + tuple.Item2)
                ).Where(fooSquare => IsKnightMoveLegal(fooSquare, board))
            );

            return output;
        }

        private bool IsKnightMoveLegal(Square square, Board board)
        {
            if (!square.IsOnTheBoard()) return false;

            var pieceAtDestSquare = board.GetPiece(square);

            if (pieceAtDestSquare == null) return true;

            return pieceAtDestSquare.Player != Player;
        }
    }
}