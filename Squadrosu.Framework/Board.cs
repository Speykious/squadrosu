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
    /// White pieces.
    /// </summary>
    public Piece[] Whites { get; private set; } = new Piece[5];

    /// <summary>
    /// Black pieces.
    /// </summary>
    public Piece[] Blacks { get; private set; } = new Piece[5];

    /// <summary>
    /// Grid where pieces are placed and moved.
    /// </summary>
    public Piece?[,] Grid { get; private set; } = new Piece[7, 7];

    public Board()
    {
        for (int i = 0; i < 5; i++)
        {
            Blacks[i] = new Piece(Player.Black, i + 1, this);
            Whites[i] = new Piece(Player.White, i + 1, this);
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
            Blacks[i].Reset();
            Whites[i].Reset();
        }
        Update();
    }
    /// <summary>
    /// Updates the positions on the board
    /// </summary>
    public void Update()
    {
        Grid = new Piece[7, 7];
        for (int i = 0; i < 5; i++)
        {
            Grid[Whites[i].Position, Whites[i].LineNumber] = Whites[i];
            Grid[Blacks[i].LineNumber, Blacks[i].Position] = Blacks[i];
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
            if (Whites[i].Direction == Direction.Finished)
                finishedWhites++;
            if (Blacks[i].Direction == Direction.Finished)
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
                s += (Grid[i, j]?.ToString() ?? "_") + " ";
            s += "\n";
        }

        return s;
    }
}
