// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using System.Collections.Generic;

namespace Squadrosu.Framework;

/// <summary>
/// Contains all the logic of the Squadro game.
/// </summary>
public sealed class Game
{
    public readonly int CurrentTurn;
    public readonly Player CurrentPlayer;
    public readonly GameState State;
    public readonly Board Board;
    public readonly List<GameAction> GameActions;

    public Game(Player firstPlayer)
    {
        CurrentTurn = 0;
        CurrentPlayer = firstPlayer;
        State = GameState.Playing;
        Board = new Board();
        GameActions = new List<GameAction>();
    }
}
