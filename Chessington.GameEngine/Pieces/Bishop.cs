using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            var availableMoves = Enumerable.Empty<Square>();
            // north east
            int i = currentSquare.Row + 1;
            int j = currentSquare.Col + 1;
            while (i < GameSettings.BoardSize && j < GameSettings.BoardSize && board.GetPieceAtCoords(i, j) == null)
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                i++;
                j++;
            }
            
            // north west
            i = currentSquare.Row + 1;
            j = currentSquare.Col - 1;
            while (i < GameSettings.BoardSize && j >= 0 && board.GetPieceAtCoords(i, j) == null)
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                i++;
                j--;
            }
            
            // south east
            i = currentSquare.Row - 1;
            j = currentSquare.Col + 1;
            while (i >= 0 && j < GameSettings.BoardSize && board.GetPieceAtCoords(i, j) == null)
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                i--;
                j++;
            }
            
            // south west
            i = currentSquare.Row - 1;
            j = currentSquare.Col - 1;
            while (i >= 0 && j >= 0 && board.GetPieceAtCoords(i, j) == null)
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                i--;
                j--;
            }
            
            return availableMoves;
        }
    }
}