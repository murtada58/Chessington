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
            HasMoved = false;
        }

        public Player Player { get; private set; }
        public bool HasMoved { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            HasMoved = true;
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        public void AddAvailableLineMoves(Board board, List<Square> availableMoves, int startingRow, int startingCol, int rowIncrement, int colIncrement)
        {
            int i = startingRow;
            int j = startingCol;
            while (board.CanMoveTo(i, j))
            {
                var availableMove = Square.At(i, j);
                availableMoves.Add(availableMove);
                i += rowIncrement;
                j += colIncrement;
            }
            if (board.InBounds(i, j) && this.Player != board.GetPieceAtCoords(i, j).Player)
            {
                var availableMove = Square.At(i, j);
                availableMoves.Add(availableMove);
            }
        }
    }
}