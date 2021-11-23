using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            var possibleMoves = new List<(int, int)>
            {
                (currentSquare.Row + 2, currentSquare.Col + 1),
                (currentSquare.Row + 2, currentSquare.Col - 1),
                (currentSquare.Row - 2, currentSquare.Col + 1),
                (currentSquare.Row - 2, currentSquare.Col - 1),
                (currentSquare.Row + 1, currentSquare.Col + 2),
                (currentSquare.Row - 1, currentSquare.Col + 2),
                (currentSquare.Row + 1, currentSquare.Col - 2),
                (currentSquare.Row - 1, currentSquare.Col - 2)
            };

            var availableMoves = new List<Square>();
            
            this.AddMovesWhereCanMoveToOrCapture(board, availableMoves, possibleMoves);
            
            return availableMoves;
        }
    }
}