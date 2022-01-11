// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using NUnit.Framework;

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
            board.White[0].Move();
            board.White[4].Move();
        }

        for (int i = 0; i < 3; i++)
        {
            board.Black[2].Move();
        }

        board.White[4].Move();
        board.Black[2].Move();
        board.White[4].Move();
        TestContext.Progress.WriteLine(board);
    }
}
