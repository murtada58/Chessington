﻿using System.Collections.Generic;
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
            
            var possibleCaptureMoves = new List<(int, int)>
            {
                (currentSquare.Row + (this.Player == Player.Black ? 1 : -1), currentSquare.Col - 1),
                (currentSquare.Row + (this.Player == Player.Black ? 1 : -1), currentSquare.Col + 1)
            };

            switch (this.Player)
            {
                case GameEngine.Player.White:
                    for (int i = 1; i <= numberOfStraightMoves; i++)
                    {
                        if (this.CanMoveTo(board, currentSquare.Row - i, currentSquare.Col))
                        {
                            var availableMove = Square.At(currentSquare.Row - i, currentSquare.Col);
                            availableMoves.Add(availableMove);
                        }
                        else { break; }
                    }
                    
                    this.AddMovesWhereCanCapture(board, availableMoves, possibleCaptureMoves);
                    break;
                
                case GameEngine.Player.Black:
                    for (int i = 1; i <= numberOfStraightMoves; i++)
                    {
                        if (this.CanMoveTo(board, currentSquare.Row + i, currentSquare.Col))
                        {
                            var availableMove = Square.At(currentSquare.Row + i, currentSquare.Col);
                            availableMoves.Add(availableMove); 
                        }
                        else { break; }
                    }
                    this.AddMovesWhereCanCapture(board, availableMoves, possibleCaptureMoves);
                    break;
            }

            return availableMoves;
        }
    }
}