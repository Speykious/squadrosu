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
}
