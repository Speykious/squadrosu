// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework;
using osu.Framework.Platform;
using Squadrosu.Game;

namespace Squadrosu.Desktop;

public static class Program
{
    public static void Main()
    {
        using GameHost host = Host.GetSuitableHost(@"Squadrosu");
        using osu.Framework.Game game = new SquadrosuGame();
        host.Run(game);
    }
}
