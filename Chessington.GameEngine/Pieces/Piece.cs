﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

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

        /// This function takes in the "directions" of a piece and traverse along those directions
        /// The legal moves are then returned.
        protected IEnumerable<Square> GetAvailableMovesWithDirection(Square square, Board board, IEnumerable<Tuple<int, int>> directions, bool isKing = false)
        {
            var output = new List<Square>();
            foreach(var direction in directions) {
                var row = square.Row + direction.Item1;
                var col = square.Col + direction.Item2;

                while (Square.At(row, col).IsOnTheBoard()) {
                    var fooSquare = Square.At(row, col);

                    if (board.IsOccupied(fooSquare)) {
                        if (board.GetPiece(fooSquare).Player != Player)
                            output.Add(fooSquare);

                        break;
                    }

                    output.Add(fooSquare);

                    if (isKing)
                        break;

                    row += direction.Item1;
                    col += direction.Item2;
                }
            }

            output.RemoveAll(s => s == square);
            return output;
        }
    }
}