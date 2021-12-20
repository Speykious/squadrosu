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
                Padding = new MarginPadding(30),
                Spacing = new Vector2(20, 10),
                Direction = FillDirection.Horizontal,
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Children = new Drawable[]
                {
                    new FloatingLogo
                    {
                        CycleDuration = 2000,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    },
                    new FloatingLogo
                    {
                        CycleDuration = 2500,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    },
                    new FloatingLogo
                    {
                        CycleDuration = 3000,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    },
                    new FloatingLogo
                    {
                        CycleDuration = 3500,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    },
                },
            },
        };
    }
}
