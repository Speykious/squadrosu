// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework;
using osu.Framework.Platform;

namespace Squadrosu.Game.Tests;

public static class Program
{
    public static void Main()
    {
        using GameHost host = Host.GetSuitableHost("visual-tests");
        using var game = new SquadrosuTestBrowser();
        host.Run(game);
    }
}
