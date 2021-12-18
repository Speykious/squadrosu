// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Platform;

namespace Squadrosu.Game.Tests.Visual;

public class TestSceneSquadrosuGame : SquadrosuTestScene
{
    // Add visual tests to ensure correct behaviour of your game: https://github.com/ppy/osu-framework/wiki/Development-and-Testing
    // You can make changes to classes associated with the tests and they will recompile and update immediately.

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
