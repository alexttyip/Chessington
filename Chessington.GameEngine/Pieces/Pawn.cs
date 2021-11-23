using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var output = new List<Square>();
            var square = board.FindPiece(this);

            if (Player == Player.White)
                output.Add(new Square(square.Row - 1, square.Col));
            else
                output.Add(new Square(square.Row + 1, square.Col));

            return output;
        }
    }
}