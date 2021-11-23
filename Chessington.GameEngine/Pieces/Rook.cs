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

            // Fill row
            for (var i = 0; i < 8; i++)
                output.Add(Square.At(square.Row, i));

            // Fill column
            for (var i = 0; i < 8; i++)
                output.Add(Square.At(i, square.Col));

            //Get rid of our starting location.
            output.RemoveAll(s => s == square);

            return output;
        }
    }
}