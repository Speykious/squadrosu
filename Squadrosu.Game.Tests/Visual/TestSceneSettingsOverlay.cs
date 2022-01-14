// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using Squadrosu.Game.UI;
using Squadrosu.Game.UI.Settings;

namespace Squadrosu.Game.Tests.Visual;

public class TestSceneSettingsOverlay : SquadrosuTestScene
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

        SquadrosuSettingsOverlay overlay;

        Add(new Container
        {
            RelativeSizeAxes = Axes.Both,
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Children = new Drawable[]
            {
                new Background("default_background")
                {
                    Blur = 15,
                    Dim = 0,
                },
                overlay = new SquadrosuSettingsOverlay(),
            },
        });

        AddStep(@"show", overlay.Show);
        AddStep(@"hide", overlay.Hide);
    }
}
