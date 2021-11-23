using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            var possibleMoves = new List<(int, int)>
            {
                (currentSquare.Row + 1, currentSquare.Col + 1),
                (currentSquare.Row + 1, currentSquare.Col),
                (currentSquare.Row + 1, currentSquare.Col - 1),
                (currentSquare.Row, currentSquare.Col + 1),
                (currentSquare.Row, currentSquare.Col - 1),
                (currentSquare.Row - 1, currentSquare.Col + 1),
                (currentSquare.Row - 1, currentSquare.Col),
                (currentSquare.Row - 1, currentSquare.Col - 1)
            };

            var availableMoves = new List<Square>();
            
            this.AddMovesWhereCanMoveToOrCapture(board, availableMoves, possibleMoves);

            
            return availableMoves;
        }
    }
}