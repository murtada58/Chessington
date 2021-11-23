using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
            HasMoved = false;
        }

        public Player Player { get; private set; }
        public bool HasMoved { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            HasMoved = true;
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

        public bool CanMoveTo(Board board, int row, int col)
        {
            if (!board.InBounds(row, col)) { return false; }
            if (board.GetPieceAtCoords(row, col) != null) { return false; }

            return true;
        }

        public bool CanCapture(Board board, int row, int col)
        {
            if (!board.InBounds(row, col)) { return false; }
            if (board.GetPieceAtCoords(row, col) == null) { return false; }
            if (this.Player == board.GetPieceAtCoords(row, col).Player) {return false; }
            
            return true;
        }
        
        public bool CanMoveToOrCapture(Board board, int row, int col)
        {
            return CanMoveTo(board, row, col) || CanCapture(board, row, col);
        }

        public void AddMovesWhereCanMoveTo(Board board, List<Square> availableMoves, List<(int, int)> moves)
        {
            foreach ((int, int) move in moves)
            {
                if (this.CanMoveTo(board, move.Item1, move.Item2))
                {
                    var availableMove = Square.At(move.Item1, move.Item2);
                    availableMoves.Add(availableMove);
                }
            }
        }

        public void AddMovesWhereCanCapture(Board board, List<Square> availableMoves, List<(int, int)> moves)
        {
            foreach ((int, int) move in moves)
            {
                if (this.CanCapture(board, move.Item1, move.Item2))
                {
                    var availableMove = Square.At(move.Item1, move.Item2);
                    availableMoves.Add(availableMove);
                }
            }
        }

        public void AddMovesWhereCanMoveToOrCapture(Board board, List<Square> availableMoves, List<(int, int)> moves)
        {
            foreach ((int, int) move in moves)
            {
                if (this.CanMoveToOrCapture(board, move.Item1, move.Item2))
                {
                    var availableMove = Square.At(move.Item1, move.Item2);
                    availableMoves.Add(availableMove);
                }
            }
        }
        
        public void AddAvailableLineMoves(Board board, List<Square> availableMoves, int startingRow, int startingCol, int rowIncrement, int colIncrement)
        {
            int i = startingRow;
            int j = startingCol;
            while (this.CanMoveTo(board, i, j))
            {
                var availableMove = Square.At(i, j);
                availableMoves.Add(availableMove);
                i += rowIncrement;
                j += colIncrement;
            }
            if (board.InBounds(i, j) && this.Player != board.GetPieceAtCoords(i, j).Player)
            {
                var availableMove = Square.At(i, j);
                availableMoves.Add(availableMove);
            }
        }
    }
}