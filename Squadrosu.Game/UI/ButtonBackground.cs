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

public class ButtonBackground : CompositeDrawable
{
    private const float default_shadow_radius = 6f;
    private const float default_shadow_opacity = .3f;
    private const float hover_shadow_radius = 14f;
    private const float hover_shadow_opacity = .3f;
    private const int duration = 200;

    private readonly Box background;
    private readonly Box hover;

    public ColourInfo Color
    {
        get => background.Colour;
        set => background.Colour = value;
    }

    public bool HasShadow { get; set; }

    public ButtonBackground(float cornerRadius = 5)
    {
        RelativeSizeAxes = Axes.Both;
        Masking = true;
        CornerRadius = cornerRadius;
        HasShadow = true;

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
            Colour = Color4.White.Opacity(.2f),
            Blending = BlendingParameters.Additive,
            Depth = float.MinValue
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
                Radius = default_shadow_radius,
                Colour = Color4.Black.Opacity(default_shadow_opacity),
            };
        }
    }

    protected override bool OnHover(HoverEvent e)
    {
        if (HasShadow)
        {
            TweenEdgeEffectTo(new EdgeEffectParameters
            {
                Type = EdgeEffectType.Shadow,
                Radius = hover_shadow_radius,
                Colour = Color4.Black.Opacity(hover_shadow_opacity),
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
                Radius = default_shadow_radius,
                Colour = Color4.Black.Opacity(default_shadow_opacity),
            }, duration, Easing.OutQuint);
        }
        hover.FadeOut(300);

        base.OnHoverLost(e);
    }
}
