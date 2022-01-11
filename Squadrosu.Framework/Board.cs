// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

namespace Squadrosu.Framework;

/// <summary>
/// Contains the state of a Squadro board.
/// </summary>
public sealed class Board
{
    /// <summary>
    /// List of White Pieces
    /// </summary>
    public Piece[] White { get; private set; } = new Piece[5];

    /// <summary>
    /// List of Black Pieces
    /// </summary>
    public Piece[] Black { get; private set; } = new Piece[5];

    /// <summary>
    /// The board itself, and positions of pieces
    /// </summary>
    public Piece?[,] Positions { get; private set; } = new Piece[7, 7];

    public Board()
    {
        for (int i = 0; i < 5; i++)
        {
            Black[i] = new Piece(Player.Black, i + 1, this);
            White[i] = new Piece(Player.White, i + 1, this);
        }
        Reset();
    }

    /// <summary>
    /// Resets the board.
    /// </summary>
    public void Reset()
    {
        for (int i = 0; i < 5; i++)
        {
            Black[i].Reset();
            White[i].Reset();
        }
        Update();
    }
    /// <summary>
    /// Updates the positions on the board
    /// </summary>
    public void Update()
    {
        Positions = new Piece[7, 7];
        for (int i = 0; i < 5; i++)
        {
            Positions[White[i].Position, White[i].LineNumber] = White[i];

            Positions[Black[i].LineNumber, Black[i].Position] = Black[i];
        }
    }

    /// <summary>
    /// Tells us if a player won or not.
    /// </summary>
    /// <returns>The winning <see cref="Player"/>, or null if the game is still ongoing.</returns>
    public Player? PlayerWon()
    {
        int finishedWhites = 0, finishedBlacks = 0;
        for (int i = 0; i < 5; i++)
        {
            if (White[i].Direction == Direction.Finished)
                finishedWhites++;
            if (Black[i].Direction == Direction.Finished)
                finishedBlacks++;
        }
        if (finishedWhites >= 4)
            return Player.White;
        else if (finishedBlacks >= 4)
            return Player.Black;
        else
            return null;
    }

    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (Positions[i, j] != null)
                    s += Positions[i, j] + "\t";
                else
                    s += "X\t";
            }
            s += "\n";
        }

        return s;
    }
}
