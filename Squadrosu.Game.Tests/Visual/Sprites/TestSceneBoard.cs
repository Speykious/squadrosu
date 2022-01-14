// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;
using Squadrosu.Game.Sprites.Game;
using Squadrosu.Game.UI;
using Squadrosu.Framework;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Allocation;

namespace Squadrosu.Game.Tests.Visual.Sprites;

public class TestSceneBoard : SquadrosuTestScene
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

        Board board = new Board();
        AddRange(new Drawable[]
        {
            new Background("default_background")
            {
                Blur = 15,
                Dim = 0,
            },
            new DrawableBoard(board)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            },
        });

        AddSliderStep("Hue", 0, 360, 0, (hue) => settings.Hue.Value = hue);
    }
}
