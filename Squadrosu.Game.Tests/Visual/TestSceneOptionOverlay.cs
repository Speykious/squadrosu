// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using Squadrosu.Game.UI;

namespace Squadrosu.Game.Tests.Visual;

public class TestSceneOptionOverlay : SquadrosuTestScene
{
    [BackgroundDependencyLoader]
    private void load()
    {
        OptionOverlay overlay;
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
                overlay = new OptionOverlay
                {
                    Children = new Drawable[]
                    {
                        new SpriteText
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Font = SquadrosuFont.GetFont(size: 50),
                            Text = @"OwOptions",
                        },
                    },
                }
            },
        });

        AddStep(@"show", overlay.Show);
        AddStep(@"hide", overlay.Hide);
    }
}
