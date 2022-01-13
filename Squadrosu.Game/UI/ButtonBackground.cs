// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Events;
using osuTK.Graphics;

namespace Squadrosu.Game.UI;

public class ButtonBackground : CompositeBackground
{
    protected const float HOVER_SHADOW_RADIUS = 14f;
    protected const float HOVER_SHADOW_OPACITY = .3f;
    private const int duration = 200;

    private readonly Box hover;

    public ButtonBackground(float cornerRadius = 5) : base(cornerRadius)
    {
        AddInternal(hover = new Box
        {
            Alpha = 0,
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.Both,
            Colour = Color4.White.Opacity(.2f),
            Blending = BlendingParameters.Additive,
            Depth = float.MinValue
        });
    }

    protected override bool OnHover(HoverEvent e)
    {
        if (HasShadow)
        {
            TweenEdgeEffectTo(new EdgeEffectParameters
            {
                Type = EdgeEffectType.Shadow,
                Radius = HOVER_SHADOW_RADIUS,
                Colour = Color4.Black.Opacity(HOVER_SHADOW_OPACITY),
            }, duration, Easing.OutQuint);
        }
        hover.FadeIn(200, Easing.OutQuint);

        return base.OnHover(e);
    }

    protected override void OnHoverLost(HoverLostEvent e)
    {
        if (HasShadow)
        {
            TweenEdgeEffectTo(new EdgeEffectParameters
            {
                Type = EdgeEffectType.Shadow,
                Radius = DEFAULT_SHADOW_RADIUS,
                Colour = Color4.Black.Opacity(DEFAULT_SHADOW_OPACITY),
            }, duration, Easing.OutQuint);
        }
        hover.FadeOut(300);

        base.OnHoverLost(e);
    }
}
