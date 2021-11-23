using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        private bool hasMoved;
        public Pawn(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var output = new List<Square>();
            var square = board.FindPiece(this);

            var playerSign = Player == Player.White ? -1 : 1;

            // Can move 1 square
            output.Add( Square.At(square.Row + 1 * playerSign, square.Col));

            // Can move 2 squares if never moved
            if (!hasMoved)
                output.Add( Square.At(square.Row + 2 * playerSign, square.Col));

            return output;
        }

        public override void MoveTo(Board board, Square newSquare)
        {
            base.MoveTo(board, newSquare);
            hasMoved = true;
        }
    }
}