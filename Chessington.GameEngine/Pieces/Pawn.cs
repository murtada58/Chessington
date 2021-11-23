using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square currentSquare = board.FindPiece(this);
            var availableMoves = Enumerable.Empty<Square>();
            if (this.Player == Player.White)
            {
                var availableMove = Square.At(currentSquare.Row - 1, currentSquare.Col);
                availableMoves = availableMoves.Append(availableMove);
            }
            else
            {
                var availableMove = Square.At(currentSquare.Row + 1, currentSquare.Col);
                availableMoves = availableMoves.Append(availableMove);
            }
        
            return availableMoves;
        }
    }
}