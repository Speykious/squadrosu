// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using System;
using NUnit.Framework;

using Squadrosu.Framework;

namespace Squadrosu.Framework.Test;

[TestFixture]
public sealed class TestBoard
{
    [Test]
    public static void IsCorrectlyInitialized()
    {
        var board = new Board();

        for (int i = 0; i <= 5; i++)
        {
            (board.White[0]).Move(board);
            board.White[4].Move(board);
        }
        for (int i = 0; i < 3; i++)
        {
            board.Black[2].Move(board);
        }
        board.White[4].Move(board);
        board.Black[2].Move(board);
        board.White[4].Move(board);
        TestContext.Progress.WriteLine(board);
    }
}
