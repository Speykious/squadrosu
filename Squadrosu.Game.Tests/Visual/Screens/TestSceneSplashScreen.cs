// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using Squadrosu.Game.Screens;

namespace Squadrosu.Game.Tests.Visual.Screens;

public class TestSceneSplashScreen : SquadrosuTestScene
{
    // Add visual tests to ensure correct behaviour of your game: https://github.com/ppy/osu-framework/wiki/Development-and-Testing
    // You can make changes to classes associated with the tests and they will recompile and update immediately.

    private SettingsOverlay? optionOverlay;

    private DependencyContainer? dependencies;
    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
        dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

    [BackgroundDependencyLoader]
    private void load()
    {
        optionOverlay = new SettingsOverlay();
        dependencies?.Cache(optionOverlay);

        Add(new ScreenStack(new SplashScreen())
        {
            RelativeSizeAxes = Axes.Both
        });
        Add(optionOverlay);
    }
}
