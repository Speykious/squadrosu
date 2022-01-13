// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using Squadrosu.Game.Screens;
using Squadrosu.Game.UI.Settings;
namespace Squadrosu.Game.Tests.Visual.Screens;

public class TestSceneMainMenuScreen : SquadrosuTestScene
{
    private SquadrosuSettingsOverlay? settingsOverlay;

    private DependencyContainer? dependencies;
    protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
        dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

    [BackgroundDependencyLoader]
    private void load()
    {
        settingsOverlay = new SquadrosuSettingsOverlay();
        dependencies?.Cache(settingsOverlay);

        Add(new ScreenStack(new MainMenuScreen())
        {
            RelativeSizeAxes = Axes.Both
        });
        Add(settingsOverlay);
    }
}
