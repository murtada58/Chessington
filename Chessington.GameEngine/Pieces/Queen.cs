using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            var availableMoves = Enumerable.Empty<Square>();
            // north
            int i = currentSquare.Row + 1;
            int j = currentSquare.Col;
            while (i < GameSettings.BoardSize && board.GetPieceAtCoords(i, j) == null)
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                i++;
            }
            
            // south
            i = currentSquare.Row - 1;
            j = currentSquare.Col;
            while (i >= 0 && board.GetPieceAtCoords(i, j) == null)
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                i--;
            }
            
            // east
            i = currentSquare.Row;
            j = currentSquare.Col + 1;
            while (j < GameSettings.BoardSize && board.GetPieceAtCoords(i, j) == null)
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                j++;
            }
            
            // west
            i = currentSquare.Row;
            j = currentSquare.Col - 1;
            while (j >= 0 && board.GetPieceAtCoords(i, j) == null)
            {
                var availableMove = Square.At(i, j);
                availableMoves = availableMoves.Append(availableMove);
                j--;
            }
            
            // north east
            i = currentSquare.Row + 1;
            j = currentSquare.Col + 1;
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