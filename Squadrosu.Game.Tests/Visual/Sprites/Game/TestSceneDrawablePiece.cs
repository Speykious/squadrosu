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

namespace Squadrosu.Game.Tests.Visual.Sprites.Game;

public class TestSceneDrawablePiece : SquadrosuTestScene
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
            new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                AutoSizeAxes = Axes.Both,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Colour = SquadrosuColor.ButtonGray,
                    },
                    new FillFlowContainer
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        AutoSizeAxes = Axes.Both,
                        Spacing = new Vector2(50),
                        Padding = new MarginPadding(20),
                        Direction = FillDirection.Vertical,
                        Children = new Drawable[]
                        {
                            new DrawablePiece(board.Whites[0]),
                            new DrawablePiece(board.Blacks[0]),
                        }
                    },
                },
            },
        });
    }
}
