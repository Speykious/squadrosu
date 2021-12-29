// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using System;
using System.Dynamic;
using System.Runtime.CompilerServices;

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

    public Piece(Player Player, int LineNumber)
    {
        Direction = Direction.Forward;
        Position = 0;
        this.LineNumber = LineNumber;
        this.Player = Player;
    }

    /// <summary>
    /// The piece returns to the initial position of the direction
    /// </summary>
    public void PlaceOnEdge()
    {
        this.Position = (this.Direction == Direction.Forward) ? 0 : 6;
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
    /// Returns the step of a piece in a given state
    /// </summary>
    /// <returns>How many squares the piece can go through</returns>
    public int Step()
    {
        if (LineNumber == 3)
            return 2;

        bool isBlack = Player == Player.Black;
        bool isForward = Direction == Direction.Forward;
        bool isOnEdge = LineNumber == 1 || LineNumber == 5;
        return isBlack ^ isForward ^ isOnEdge ? 3 : 1;
    }

    /// <summary>
    /// Move the position of the piece
    /// </summary>
    public void Move(Board board)
    {
        if (this.Direction == Direction.Forward)
            this.moveForward(board);
        else if (this.Direction == Direction.Backward)
            this.moveBackward(board);
    }

    /// <summary>
    /// Move the piece if its direction is forward
    /// </summary>
    /// <param name="board">The current board</param>
    private void moveForward(Board board)
    {
        int step = this.Step();
        int newPosition = Math.Min(this.Position + step, 6);
        bool isBlack = (this.Player == Player.Black);
        int i = this.Position;

        while (i + 1 <= Math.Min(this.Position + step, 5))
        {
            if (isBlack)
            {
                if (board.Positions[this.LineNumber, i + 1] != null)
                {
                    while (board.Positions[this.LineNumber, i + 1] != null)
                    {
                        board.Positions[this.LineNumber, i + 1].PlaceOnEdge();
                        newPosition = i + 2;
                        i++;
                    }
                    i = 7;
                }
            }
            else
            {
                if (board.Positions[i + 1, this.LineNumber] != null)
                {
                    while (board.Positions[i + 1, this.LineNumber] != null)
                    {
                        board.Positions[i + 1, this.LineNumber].PlaceOnEdge();
                        newPosition = i + 2;
                        i++;
                    }
                    i = 7;
                }
            }
            i++;
        }

        this.Position = newPosition;
        if (newPosition == 6)
            this.Direction = Direction.Backward;
        board.Update();
    }

    /// <summary>
    /// Move the piece if its dierction is Bakcward
    /// </summary>
    /// <param name="board">The current Board</param>
    private void moveBackward(Board board)
    {
        int step = this.Step();
        int newPosition = Math.Max(this.Position - step, 0);
        bool isBlack = (this.Player == Player.Black);
        int i = this.Position;

        while (i - 1 >= Math.Max(this.Position - step, 1))
        {
            if (isBlack)
            {
                if (board.Positions[this.LineNumber, i - 1] != null)
                {
                    while (board.Positions[this.LineNumber, i - 1] != null)
                    {
                        board.Positions[this.LineNumber, i - 1].Reset();
                        newPosition = i - 2;
                        i--;
                    }
                    i = -1;
                }
            }
            else
            {
                if (board.Positions[i - 1, this.LineNumber] != null)
                {
                    while (board.Positions[i - 1, this.LineNumber] != null)
                    {
                        board.Positions[i - 1, this.LineNumber].Reset();
                        newPosition = i - 2;
                        i--;
                    }
                    i = -1;
                }
            }
            i--;
        }

        this.Position = newPosition;
        if (newPosition == 0)
            this.Direction = Direction.Finished;
        board.Update();
    }


    public override string ToString() => Player == Player.Black ? "B" : "W";
}
