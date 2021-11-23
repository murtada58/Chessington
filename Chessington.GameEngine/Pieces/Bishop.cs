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
            var availableMoves = new List<Square>();
            var moveSets = new List<(int, int, int, int)>
            {
                (currentSquare.Row + 1, currentSquare.Col + 1, 1, 1),
                (currentSquare.Row - 1, currentSquare.Col - 1, -1, -1),
                (currentSquare.Row + 1, currentSquare.Col - 1, 1, -1),
                (currentSquare.Row - 1, currentSquare.Col + 1, -1, 1)
            };

            foreach (var moveSet in moveSets)
            {
                this.AddAvailableLineMoves(board, availableMoves, moveSet.Item1, moveSet.Item2, moveSet.Item3, moveSet.Item4);
            }
            
            return availableMoves;
        }
    }
}