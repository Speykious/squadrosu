// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;

namespace Squadrosu.Game.Components;

public class ButtonBackground : CompositeDrawable
{
    private const int duration = 200;
    private readonly Box background;
    private readonly Box hover;

    public ColourInfo Color
    {
        get => background.Colour;
        set => background.Colour = value;
    }

    public ButtonBackground(float cornerRadius = 5)
    {
        RelativeSizeAxes = Axes.Both;
        Masking = true;
        CornerRadius = cornerRadius;
        EdgeEffect = new EdgeEffectParameters
        {
            Type = EdgeEffectType.Shadow,
            Radius = 4f,
            Colour = Color4.Black.Opacity(0.5f),
        };
        AddInternal(background = new Box
        {
            RelativeSizeAxes = Axes.Both,
        });
        AddInternal(hover = new Box
        {
            Alpha = 0,
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.Both,
            Colour = Color4.White.Opacity(.5f),
            Blending = BlendingParameters.Additive,
            Depth = float.MinValue
        });
    }

    protected override bool OnHover(HoverEvent e)
    {
        TweenEdgeEffectTo(new EdgeEffectParameters
        {
            Type = EdgeEffectType.Shadow,
            Radius = 10f,
            Offset = new Vector2(0, 1),
            Colour = Color4.Black.Opacity(0.4f),
        }, duration, Easing.OutQuint);
        hover.FadeIn(200, Easing.OutQuint);

        return base.OnHover(e);
    }

    protected override void OnHoverLost(HoverLostEvent e)
    {
        TweenEdgeEffectTo(new EdgeEffectParameters
        {
            Type = EdgeEffectType.Shadow,
            Radius = 4f,
            Colour = Color4.Black.Opacity(0.5f),
        }, duration, Easing.OutQuint);
        hover.FadeOut(300);

        base.OnHoverLost(e);
    }
}
