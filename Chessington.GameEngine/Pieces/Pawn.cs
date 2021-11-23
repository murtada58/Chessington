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
            var availableMoves = new List<Square>();
            int numberOfStraightMoves = HasMoved ? 1 : 2;
            
            this.AddAvailablePawnStraightMoves( board,
                                                availableMoves,
                                                currentSquare.Row,
                                                currentSquare.Col,
                                                (this.Player == Player.White ? -1 : 1),
                                                numberOfStraightMoves);

            
            var possibleCaptureMoves = new List<(int, int)>
            {
                (currentSquare.Row + (this.Player == Player.White ? -1 : 1), currentSquare.Col - 1),
                (currentSquare.Row + (this.Player == Player.White ? -1 : 1), currentSquare.Col + 1)
            };
            this.AddMovesWhereCanCapture(board, availableMoves, possibleCaptureMoves);

            return availableMoves;
        }
        
        public void AddAvailablePawnStraightMoves(  Board board,
            List<Square> availableMoves,
            int row,
            int col,
            int direction,
            int numberOfStraightMoves
        )
        {
            for (int i = direction; i * direction <= numberOfStraightMoves; i += direction)
            {
                if (this.CanMoveTo(board, row + i, col))
                {
                    var availableMove = Square.At(row + i, col);
                    availableMoves.Add(availableMove); 
                }
                else { break; }
            }
        }
    }
}