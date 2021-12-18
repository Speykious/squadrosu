// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace Squadrosu.Game;

public class SpinningBox : CompositeDrawable
{
    private readonly Container box;

    public SpinningBox()
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
            new Box
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            },
            new Sprite
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Texture = textures.Get("logo")
            },
        };

        InternalChild = box;
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();
        box.Loop(b => b.RotateTo(0).RotateTo(360, 2500));
    }
}
