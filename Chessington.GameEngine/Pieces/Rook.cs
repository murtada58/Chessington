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
            // up
            int i = currentSquare.Row + 1;
            int j = currentSquare.Col;
            while (i < GameSettings.BoardSize && board.GetPieceAtCoords(i, j) == null)
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                i++;
            }
            
            // down
            i = currentSquare.Row - 1;
            j = currentSquare.Col;
            while (i >= 0 && board.GetPieceAtCoords(i, j) == null)
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                i--;
            }
            
            // right
            i = currentSquare.Row;
            j = currentSquare.Col + 1;
            while (j < GameSettings.BoardSize && board.GetPieceAtCoords(i, j) == null)
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                j++;
            }
            
            // left
            i = currentSquare.Row;
            j = currentSquare.Col - 1;
            while (j >= 0 && board.GetPieceAtCoords(i, j) == null)
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                j--;
            }
            
            return availableMoves;
        }
    }
}