// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;
using osuTK.Graphics;
using Squadrosu.Game.Sprites;

namespace Squadrosu.Game.Screens;

public class SplashScreen : Screen
{
    private readonly SquareLogo logo;

    public SplashScreen()
    {
        InternalChildren = new Drawable[]
        {
            new Box
            {
                Colour = Color4.Black,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            },
            logo = new SquareLogo
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            }
        };
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();
        logo.Delay(2000).FadeOutFromOne(500, Easing.InSine);
    }
}
