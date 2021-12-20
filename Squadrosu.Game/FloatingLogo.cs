// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace Squadrosu.Game;

public class FloatingLogo : CompositeDrawable
{
    private readonly Container box;
    public double CycleDuration { get; set; }

    public FloatingLogo()
    {
        AutoSizeAxes = Axes.Both;
        Origin = Anchor.Centre;

        box = new Container
        {
            AutoSizeAxes = Axes.Both,
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
        };
    }

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        box.Children = new Drawable[]
        {
            new Sprite
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Texture = textures.Get(@"logo/squadrosu_logo_square"),
            },
        };

        InternalChild = box;
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();
        double d = CycleDuration / 4;
        float amplitude = 50;

        box.MoveToY(amplitude, duration: d, easing: Easing.OutSine)
        .Then().MoveToY(0, duration: d, easing: Easing.InSine)
        .Then().MoveToY(-amplitude, duration: d, easing: Easing.OutSine)
        .Then().MoveToY(0, duration: d, easing: Easing.InSine)
        .Loop();
    }
}
