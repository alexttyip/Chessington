using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public virtual void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        protected static IEnumerable<Square> GetAvailableMovesWithDirection(Square square, Board board, IEnumerable<Tuple<int, int>> directions)
        {
            var output = new List<Square>();
            foreach(var direction in directions) {
                var row = square.Row + direction.Item1;
                var col = square.Col + direction.Item2;

                while (Square.At(row, col).IsOnTheBoard()) {
                    var fooSquare = Square.At(row, col);

                    if (board.IsOccupied(fooSquare)) break;

                    output.Add(fooSquare);

                    row += direction.Item1;
                    col += direction.Item2;
                }
            }

            output.RemoveAll(s => s == square);
            return output;
        }
    }
}