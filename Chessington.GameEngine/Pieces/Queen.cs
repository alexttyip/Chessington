using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var output = new List<Square>();
            var square = board.FindPiece(this);

            // Fill row
            for (var i = 0; i < 8; i++)
                output.Add(Square.At(square.Row, i));

            // Fill column
            for (var i = 0; i < 8; i++)
                output.Add(Square.At(i, square.Col));

            // Diagonals
            for (var i = 0; i < 8; i++)
                output.Add(Square.At(i, i));

            for (var i = 1; i < 8; i++)
                output.Add(Square.At(i, 8 - i));

            output.RemoveAll(s => s == square);

            return output;
        }
    }
}