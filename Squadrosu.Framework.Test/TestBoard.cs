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
            board.Whites[0].Move();
            board.Whites[4].Move();
        }

        for (int i = 0; i < 3; i++)
        {
            board.Blacks[2].Move();
        }

        board.Whites[4].Move();
        board.Blacks[2].Move();
        board.Whites[4].Move();
        TestContext.Progress.WriteLine(board);
    }
}
