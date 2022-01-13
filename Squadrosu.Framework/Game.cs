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
    /// <summary>
    /// Number of the current turn.
    /// </summary>
    public int CurrentTurn { get; private set; }
    /// <summary>
    /// Current player.
    /// </summary>
    public Player CurrentPlayer { get; private set; }
    /// <summary>
    /// State of the game: whether it is playing or if some player won.
    /// </summary>
    public GameState State { get; private set; }
    /// <summary>
    /// Board containing the pieces. Used to determine if a player as won.
    /// </summary>
    public readonly Board Board;
    /// <summary>
    /// A record of all the player moves so far.
    /// </summary>
    public readonly List<GameAction> History;

    public Game(Player firstPlayer)
    {
        Board = new Board();
        History = new List<GameAction>();
        Reset(firstPlayer);
    }

    /// <summary>
    /// Goes to the next turn.
    /// </summary>
    private void nextTurn()
    {
        CurrentPlayer = CurrentPlayer == Player.White ? Player.Black : Player.White;
        CurrentTurn++;
    }

    /// <summary>
    /// Updates the <see cref="GameState"/> of the game.
    /// </summary>
    private void updateState()
    {
        switch (Board.PlayerWon())
        {
            case Player.White:
                State = GameState.WhiteWon;
                break;
            case Player.Black:
                State = GameState.BlackWon;
                break;
            default:
                State = GameState.Playing;
                break;
        }
    }

    /// <summary>
    /// Makes the current player move a given piece.
    /// </summary>
    /// <returns>Whether the piece has actually been moved.</returns>
    public bool Move(Piece piece)
    {
        if (State != GameState.Playing)
            return false;

        piece.Move();

        History.Add(new GameAction
        {
            Player = CurrentPlayer,
            LineNumber = piece.LineNumber,
        });

        updateState();

        if (State == GameState.Playing)
            nextTurn();

        return true;
    }

    /// <summary>
    /// Resets the game.
    /// </summary>
    /// <param name="firstPlayer">The first player to make a move.</param>
    public void Reset(Player firstPlayer)
    {
        Board.Reset();
        CurrentTurn = 0;
        CurrentPlayer = firstPlayer;
        State = GameState.Playing;
        History.Clear();
    }
}
