// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osuTK.Input;
using Squadrosu.Game.Screens;

namespace Squadrosu.Game;

public class SquadrosuGame : SquadrosuGameBase
{
    private ScreenStack? screenStack;
    private OptionOverlay? optionOverlay;

    private DependencyContainer? dependencies;
    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
        dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

    [BackgroundDependencyLoader]
    private void load()
    {
        optionOverlay = new OptionOverlay();
        dependencies?.Cache(optionOverlay);

        Children = new Drawable[]
        {
            screenStack = new ScreenStack
            {
                RelativeSizeAxes = Axes.Both,
            },
            optionOverlay,
        };
    }

    protected override bool OnKeyDown(KeyDownEvent e)
    {
        if (!e.Repeat && e.Key == Key.O)
        {
            optionOverlay?.Show();
            return true;
        }

        return base.OnKeyDown(e);
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();

        screenStack?.Push(new SplashScreen());
    }
}
