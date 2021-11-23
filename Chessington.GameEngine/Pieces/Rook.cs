using System;
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
            var availableMoves = new List<Square>();
            var moveSets = new List<(int, int, int, int)>
            {
                (currentSquare.Row + 1, currentSquare.Col, 1, 0),
                (currentSquare.Row - 1, currentSquare.Col, -1, 0),
                (currentSquare.Row, currentSquare.Col + 1, 0, 1),
                (currentSquare.Row, currentSquare.Col - 1, 0, -1),
            };

            foreach (var moveSet in moveSets)
            {
                this.AddAvailableLineMoves(board, availableMoves, moveSet.Item1, moveSet.Item2, moveSet.Item3, moveSet.Item4);
            }
            
            return availableMoves;
        }
    }
}