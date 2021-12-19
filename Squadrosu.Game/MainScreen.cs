// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

namespace Squadrosu.Game;

public class MainScreen : Screen
{
    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren = new Drawable[]
        {
            new Box
            {
                Colour = Color4Extensions.FromHex(@"222430"),
                RelativeSizeAxes = Axes.Both,
            },
            new SpriteText
            {
                Y = 20,
                Text = "Main Screen",
                Anchor = Anchor.TopCentre,
                Origin = Anchor.TopCentre,
                Font = FontUsage.Default.With(size: 40)
            },
            new FillFlowContainer
            {
                Masking = true,
                BorderColour = Color4Extensions.FromHex(@"ffffff"),
                BorderThickness = 5,
                Padding = new MarginPadding(30),
                Spacing = new Vector2(20, 10),
                Direction = FillDirection.Horizontal,
                Size = new Vector2(800, 400),
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Children = new Drawable[]
                {
                    new SpinningBox
                    {
                        Anchor = Anchor.Centre,
                    },
                    new SpinningBox
                    {
                        Anchor = Anchor.Centre,
                    },
                    new SpinningBox
                    {
                        Anchor = Anchor.Centre,
                    },
                    new SpinningBox
                    {
                        Anchor = Anchor.Centre,
                    },
                }
            },
        };
    }
}
