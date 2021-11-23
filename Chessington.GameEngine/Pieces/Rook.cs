using System;
using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var output = new List<Square>();
            var square = board.FindPiece(this);

            // Leftmost and rightmost square a rook can travel on its row
            var leftmost = 0;
            var rightmost = 7;
            // Top and bottom square a rook can travel on its column
            var top = 0;
            var bottom = 7;

            for (var i = 0; i < square.Col; i++)
                if (board.IsOccupied(Square.At(square.Row, i)))
                    leftmost = i + 1;

            for (var i = 7; i > square.Col; i--)
                if (board.IsOccupied(Square.At(square.Row, i)))
                    rightmost = i - 1;

            for (var i = 0; i < square.Row; i++)
                if (board.IsOccupied(Square.At(i, square.Col)))
                    top = i + 1;

            for (var i = 7; i > square.Row; i--)
                if (board.IsOccupied(Square.At(i, square.Col)))
                    bottom = i - 1;

            // Fill row
            for (var i = leftmost; i <= rightmost; i++)
                output.Add(Square.At(square.Row, i));

            // Fill column
            for (var i = top; i <= bottom; i++)
                output.Add(Square.At(i, square.Col));

            //Get rid of our starting location.
            output.RemoveAll(s => s == square);

            return output;
        }
    }
}