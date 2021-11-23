using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            var availableMoves = Enumerable.Empty<Square>();
            // north
            int i = currentSquare.Row + 1;
            int j = currentSquare.Col;
            while (board.CanMoveTo(i, j))
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                i++;
            }
            
            // south
            i = currentSquare.Row - 1;
            j = currentSquare.Col;
            while (board.CanMoveTo(i, j))
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                i--;
            }
            
            // east
            i = currentSquare.Row;
            j = currentSquare.Col + 1;
            while (board.CanMoveTo(i, j))
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                j++;
            }
            
            // west
            i = currentSquare.Row;
            j = currentSquare.Col - 1;
            while (board.CanMoveTo(i, j))
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                j--;
            }

            return availableMoves;
        }
    }
}