// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using System;

namespace Squadrosu.Framework;

/// <summary>
/// Contains the state of a Squadro board.
/// </summary>
public sealed class Board
{
    /// <summary>
    /// Resets the board.
    /// </summary>
    public void Reset()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Will move a player's piece on the board.
    /// </summary>
    /// <returns>Whether the piece has actually been moved.</returns>
    public bool Move(Piece piece, Player player)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Tells us if a player won or not.
    /// </summary>
    /// <returns>The winning <see cref="Player"/>, or null if the game is still ongoing.</returns>
    public Player? PlayerWon()
    {
        throw new NotImplementedException();
    }
}
