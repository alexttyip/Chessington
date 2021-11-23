using System.Collections.Generic;

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

            foreach(var i in new[] { -2, 2 }) {
                foreach(var j in new[] { -1, 1 }) {
                    output.Add(new Square(square.Row + i, square.Col + j));
                    output.Add(new Square(square.Row + j, square.Col + i));
                }
            }

            return output;
        }
    }
}