// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Platform;

namespace Squadrosu.Game.Tests.Visual;

public class TestSceneSquadrosuGame : SquadrosuTestScene
{
    private readonly SquadrosuGame game;

    public TestSceneSquadrosuGame() : base()
    {
        game = new SquadrosuGame();
    }

    [BackgroundDependencyLoader]
    private void load(GameHost host)
    {
        game.SetHost(host);
        AddGame(game);
    }
}
