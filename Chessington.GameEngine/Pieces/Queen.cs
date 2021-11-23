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
            var availableMoves = new List<Square>();
            var lineMoves = new List<(int, int, int, int)>
            {
                (currentSquare.Row + 1, currentSquare.Col, 1, 0),
                (currentSquare.Row - 1, currentSquare.Col, -1, 0),
                (currentSquare.Row, currentSquare.Col + 1, 0, 1),
                (currentSquare.Row, currentSquare.Col - 1, 0, -1),
                (currentSquare.Row + 1, currentSquare.Col + 1, 1, 1),
                (currentSquare.Row - 1, currentSquare.Col - 1, -1, -1),
                (currentSquare.Row + 1, currentSquare.Col - 1, 1, -1),
                (currentSquare.Row - 1, currentSquare.Col + 1, -1, 1)
            };

            foreach (var lineMove in lineMoves)
            {
                this.AddAvailableLineMoves( board,
                                            availableMoves,
                                            lineMove.Item1,
                                            lineMove.Item2,
                                            lineMove.Item3,
                                            lineMove.Item4
                                            );
            }
            
            return availableMoves;
        }
    }
}