// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using Squadrosu.Game.Screens;
namespace Squadrosu.Game.Tests.Visual.Screens;

public class TestSceneSquadrosuGameScreen : SquadrosuTestScene
{
    private Settings? settings;

    private DependencyContainer? dependencies;
    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
        dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

    [BackgroundDependencyLoader]
    private void load()
    {
        settings = new Settings();
        dependencies?.Cache(settings);

        Add(new ScreenStack(new SquadrosuGameScreen())
        {
            RelativeSizeAxes = Axes.Both
        });
    }
}
