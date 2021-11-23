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
            switch (this.Player)
            {
                case GameEngine.Player.White:
                    for (int i = 1; i <= numberOfStraightMoves; i++)
                    {
                        if (board.CanMoveTo(currentSquare.Row - i, currentSquare.Col))
                        {
                            var availableMove = Square.At(currentSquare.Row - i, currentSquare.Col);
                            availableMoves = availableMoves.Append(availableMove);
                        }
                        else { break; }
                    }
                    break;
                
                case GameEngine.Player.Black:
                    for (int i = 1; i <= numberOfStraightMoves; i++)
                    {
                        if (board.CanMoveTo(currentSquare.Row + i, currentSquare.Col))
                        {
                            var availableMove = Square.At(currentSquare.Row + i, currentSquare.Col);
                            availableMoves = availableMoves.Append(availableMove); 
                        }
                        else { break; }
                    }
                    break;
            }

            return availableMoves;
        }
    }
}