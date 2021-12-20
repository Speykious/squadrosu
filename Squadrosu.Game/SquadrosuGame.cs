// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using Squadrosu.Game.Screens;

namespace Squadrosu.Game;

public class SquadrosuGame : SquadrosuGameBase
{
    private readonly ScreenStack screenStack;

    public SquadrosuGame() : base()
    {
        screenStack = new ScreenStack
        {
            RelativeSizeAxes = Axes.Both,
        };
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        // Add your top-level game components here.
        // A screen stack and sample screen has been provided for convenience, but you can replace it if you don't want to use screens.
        Child = screenStack;
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();

        screenStack.Push(new SplashScreen());
    }
}
