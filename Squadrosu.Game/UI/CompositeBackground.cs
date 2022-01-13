// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;
using osuTK.Graphics;

namespace Squadrosu.Game.UI;

public class CompositeBackground : CompositeDrawable
{
    protected const float DEFAULT_SHADOW_RADIUS = 6f;
    protected const float DEFAULT_SHADOW_OPACITY = .3f;

    private readonly Box background;

    public ColourInfo Color
    {
        get => background.Colour;
        set => background.Colour = value;
    }

    public bool HasShadow { get; set; }

    public CompositeBackground(float cornerRadius = 5)
    {
        RelativeSizeAxes = Axes.Both;
        Masking = true;
        CornerRadius = cornerRadius;
        HasShadow = true;

        AddInternal(background = new Box
        {
            RelativeSizeAxes = Axes.Both,
        });
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        if (HasShadow)
        {
            EdgeEffect = new EdgeEffectParameters
            {
                Type = EdgeEffectType.Shadow,
                Radius = DEFAULT_SHADOW_RADIUS,
                Colour = Color4.Black.Opacity(DEFAULT_SHADOW_OPACITY),
            };
        }
    }
}
