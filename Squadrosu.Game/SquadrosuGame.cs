// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osuTK.Input;
using Squadrosu.Game.Screens;
using Squadrosu.Game.UI.Settings;

namespace Squadrosu.Game;

public class SquadrosuGame : SquadrosuGameBase
{
    private ScreenStack? screenStack;
    private SettingsOverlay? settingsOverlay;
    private Settings? settings;

    private DependencyContainer? dependencies;
    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
        dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

    [BackgroundDependencyLoader]
    private void load()
    {
        settingsOverlay = new SquadrosuSettingsOverlay();
        dependencies?.Cache(settingsOverlay);

        settings = new Settings();
        dependencies?.Cache(settings);

        Children = new Drawable[]
        {
            screenStack = new ScreenStack
            {
                RelativeSizeAxes = Axes.Both,
            },
            settingsOverlay,
        };
    }

    protected override bool OnKeyDown(KeyDownEvent e)
    {
        if (!e.Repeat && e.Key == Key.O)
        {
            settingsOverlay?.Show();
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
