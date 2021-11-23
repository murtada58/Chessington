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
            int numberOfStraightMoves = HasMoved ? 1 : 2;
            if (this.Player == Player.White)
            {
                for (int i = 1; i <= numberOfStraightMoves; i++)
                {
                    var availableMove = Square.At(currentSquare.Row - i, currentSquare.Col);
                    availableMoves = availableMoves.Append(availableMove); 
                }
            }
            else
            {
                for (int i = 1; i <= numberOfStraightMoves; i++)
                {
                    var availableMove = Square.At(currentSquare.Row + i, currentSquare.Col);
                    availableMoves = availableMoves.Append(availableMove); 
                }
            }
        
            return availableMoves;
        }
    }
}