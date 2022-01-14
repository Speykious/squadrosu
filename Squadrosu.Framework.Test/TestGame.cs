// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using System;
using NUnit.Framework;

namespace Squadrosu.Framework.Test;

[TestFixture]
public sealed class TestGame
{
    private static readonly int[] white_steps = new int[] { 1, 3, 2, 3, 1 };
    private static readonly int[] black_steps = new int[] { 3, 1, 2, 1, 3 };

    private static void multipleMove(Piece piece, int nb)
    {
        for (int i = 0; i < nb; i++)
            piece.Move();
    }
    private static void multipleMove(Game game, Piece piece, int nb)
    {
        for (int i = 0; i < nb; i++)
            game.Move(piece);
    }

    [Test]
    public static void BoardIsCorrectlyInitialized()
    {
        var board = new Board();
        TestContext.Progress.WriteLine($"Initialized board\n{board}");
        piecesAreCorrectlyInitialized(board, Player.White);
        piecesAreCorrectlyInitialized(board, Player.Black);
    }

    private static void piecesAreCorrectlyInitialized(Board board, Player player)
    {
        Piece?[] pieces = player == Player.White ? board.Whites : board.Blacks;
        for (int i = 0; i < 5; i++)
        {
            Piece? piece = pieces[i];
            Assert.NotNull(piece);
            if (piece == null)
                return;

            Assert.Zero(piece.Position);
            Assert.AreEqual(piece.LineNumber, i + 1);
            Assert.AreEqual(piece?.Player, player);
        }
    }

    [Test]
    public static void PiecesHaveRightStep()
    {
        var board = new Board();
        foreach (var piece in board.Whites)
            piece.Move();
        TestContext.Progress.WriteLine($"White steps\n{board}");

        for (int i = 0; i < 5; i++)
        {
            Piece piece = board.Whites[i];
            Assert.AreEqual(piece.Step, white_steps[i]);
            Assert.AreEqual(piece.Position, piece.Step);
        }

        board.Reset();
        foreach (var piece in board.Blacks)
            piece.Move();
        TestContext.Progress.WriteLine($"Black steps\n{board}");

        for (int i = 0; i < 5; i++)
        {
            Piece piece = board.Blacks[i];
            Assert.AreEqual(piece.Step, black_steps[i]);
            Assert.AreEqual(piece.Position, piece.Step);
        }
    }

    [Test]
    public static void PassedPiecesGetReset()
    {
        Board board = new Board();
        board.Whites[0].Move();
        board.Whites[2].Move();
        board.Whites[3].Move();
        TestContext.Progress.WriteLine($"White steps\n{board}");

        multipleMove(board.Blacks[0], 1);
        multipleMove(board.Blacks[2], 2);
        multipleMove(board.Blacks[1], 3);
        TestContext.Progress.WriteLine($"Black steps\n{board}");

        for (int i = 0; i < 5; i++)
            Assert.AreEqual(board.Whites[i].Position, 0);
        Assert.AreEqual(board.Blacks[0].Position, 2);
        Assert.AreEqual(board.Blacks[1].Position, 4);
        Assert.AreEqual(board.Blacks[2].Position, 5);
    }

    [Test]
    public static void ChangeDirectionWorking()
    {
        Board board = new Board();
        Assert.AreEqual(board.Blacks[0].Direction, Direction.Forward);
        Assert.AreEqual(board.Whites[2].Direction, Direction.Forward);
        multipleMove(board.Blacks[0], 2);
        multipleMove(board.Whites[2], 3);
        Assert.AreEqual(board.Blacks[0].Direction, Direction.Backward);
        Assert.AreEqual(board.Whites[2].Direction, Direction.Backward);
        multipleMove(board.Blacks[0], 6);
        multipleMove(board.Whites[2], 3);
        Assert.AreEqual(board.Blacks[0].Direction, Direction.Finished);
        Assert.AreEqual(board.Whites[2].Direction, Direction.Finished);
    }

    [Test]
    public static void CanAPlayerWin()
    {
        Game game = new Game(Player.Black);
        Assert.AreEqual(game.State, GameState.Playing);

        multipleMove(game, game.Board.Blacks[4], 3);
        multipleMove(game, game.Board.Blacks[0], 10);
        multipleMove(game, game.Board.Blacks[1], 10);
        multipleMove(game, game.Board.Blacks[2], 10);
        multipleMove(game, game.Board.Blacks[3], 10);
        TestContext.Progress.WriteLine($"Black steps\n{game.Board}");
        Assert.AreEqual(game.State, GameState.BlackWon);

        game.Reset(Player.White);
        multipleMove(game, game.Board.Whites[4], 3);
        multipleMove(game, game.Board.Whites[0], 10);
        multipleMove(game, game.Board.Whites[1], 10);
        multipleMove(game, game.Board.Whites[2], 10);
        multipleMove(game, game.Board.Whites[3], 10);
        TestContext.Progress.WriteLine($"White steps\n{game.Board}");
        Assert.AreEqual(game.State, GameState.WhiteWon);
    }
}
