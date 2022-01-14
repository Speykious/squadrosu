// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using System;

namespace Squadrosu.Framework;

public class Piece
{
    /// <summary>
    /// To which player is the current piece
    /// </summary>
    public readonly Player Player;
    /// <summary>
    /// Direction of the piece
    /// </summary>
    public Direction Direction { get; private set; }
    /// <summary>
    /// Position in the row
    /// </summary>
    public int Position { get; private set; }
    /// <summary>
    /// Line number
    /// </summary>
    public readonly int LineNumber;
    /// <summary>
    /// Returns the step of a piece in a given state
    /// </summary>
    /// <returns>How many squares the piece can go through</returns>
    public int Step
    {
        get
        {
            if (LineNumber == 3)
                return 2;

            bool isBlack = Player == Player.Black;
            bool isForward = Direction == Direction.Forward;
            bool isOnEdge = LineNumber == 1 || LineNumber == 5;
            return isBlack ^ isForward ^ isOnEdge ? 3 : 1;
        }
    }

    /// <summary>
    /// The board in which the piece plays
    /// </summary>
    public readonly Board Board;

    public Piece(Player player, int lineNumber, Board board)
    {
        Direction = Direction.Forward;
        Position = 0;
        LineNumber = lineNumber;
        Player = player;
        Board = board;
    }

    /// <summary>
    /// The piece returns to the initial position of the direction
    /// </summary>
    public void PlaceOnEdge()
    {
        Position = (Direction == Direction.Forward) ? 0 : 6;
    }
    /// <summary>
    /// Place the piece on edge
    /// </summary>
    public void Reset()
    {
        Direction = Direction.Forward;
        PlaceOnEdge();
    }

    /// <summary>
    /// Move the position of the piece
    /// </summary>
    public bool Move()
    {
        if (Direction == Direction.Forward)
            moveForward();
        else if (Direction == Direction.Backward)
            moveBackward();
        else
            return false;

        return true;
    }

    /// <summary>
    /// Move the piece if its direction is forward
    /// </summary>
    /// <param name="board">The current board</param>
    private void moveForward()
    {
        int newPosition = Math.Min(Position + Step, 6);
        bool isBlack = Player == Player.Black;
        Piece? piece;

        int i = Position;
        while (i + 1 <= Math.Min(Position + Step, 5))
        {
            if (isBlack)
            {
                if (Board.Grid[LineNumber, i + 1] != null)
                {
                    while ((piece = Board.Grid[LineNumber, i + 1]) != null)
                    {
                        piece.PlaceOnEdge();
                        newPosition = i + 2;
                        i++;
                    }
                    i = 7;
                }
            }
            else
            {
                if (Board.Grid[i + 1, LineNumber] != null)
                {
                    while ((piece = Board.Grid[i + 1, LineNumber]) != null)
                    {
                        piece.PlaceOnEdge();
                        newPosition = i + 2;
                        i++;
                    }
                    i = 7;
                }
            }
            i++;
        }

        Position = newPosition;
        if (newPosition == 6)
            Direction = Direction.Backward;
        Board.Update();
    }

    /// <summary>
    /// Move the piece if its dierction is Bakcward
    /// </summary>
    /// <param name="board">The current Board</param>
    private void moveBackward()
    {
        int newPosition = Math.Max(Position - Step, 0);
        bool isBlack = Player == Player.Black;
        Piece? piece;

        int i = Position;
        while (i - 1 >= Math.Max(Position - Step, 1))
        {
            if (isBlack)
            {
                if (isBlack && Board.Grid[LineNumber, i - 1] != null)
                {
                    while ((piece = Board.Grid[LineNumber, i - 1]) != null)
                    {
                        piece.PlaceOnEdge();
                        newPosition = i - 2;
                        i--;
                    }
                    i = -1;
                }
            }
            else
            {
                if (Board.Grid[i - 1, LineNumber] != null)
                {
                    while ((piece = Board.Grid[i - 1, LineNumber]) != null)
                    {
                        piece.PlaceOnEdge();
                        newPosition = i - 2;
                        i--;
                    }
                    i = -1;
                }
            }
            i--;
        }

        Position = newPosition;
        if (newPosition == 0)
            Direction = Direction.Finished;
        Board.Update();
    }

    public override string ToString() => Player == Player.Black ? "B" : "W";
}
