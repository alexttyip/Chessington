using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var output = new List<Square>();
            var square = board.FindPiece(this);

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