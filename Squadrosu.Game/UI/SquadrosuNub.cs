// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using System;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Shapes;
using osuTK;
using osuTK.Graphics;

namespace Squadrosu.Game.UI.Settings;

public class SquadrosuNub : CompositeDrawable
{
    public const float HEIGHT = 15;

    public const float EXPANDED_SIZE = 50;

    private const float border_width = 3;

    private const double animate_in_duration = 200;
    private const double animate_out_duration = 500;

    private readonly Box fill;
    private readonly Container main;

    public SquadrosuNub()
    {
        Size = new Vector2(EXPANDED_SIZE, HEIGHT);

        InternalChildren = new[]
        {
                main = new CircularContainer
                {
                    BorderColour = Color4.White,
                    BorderThickness = border_width,
                    Masking = true,
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Children = new Drawable[]
                    {
                        fill = new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                            Alpha = 0,
                            AlwaysPresent = true,
                        },
                    }
                },
            };
    }

    [BackgroundDependencyLoader(true)]
    private void load()
    {
        main.EdgeEffect = new EdgeEffectParameters
        {
            Colour = GlowColour.Opacity(0f),
            Type = EdgeEffectType.Glow,
            Radius = 8,
            Roundness = 5,
        };
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();

        Current.BindValueChanged(onCurrentValueChanged, true);
    }

    private bool glowing;

    public bool Glowing
    {
        get => glowing;
        set
        {
            glowing = value;

            if (value)
            {
                main.FadeColour(GlowingAccentColour, animate_in_duration, Easing.OutQuint);
                main.FadeEdgeEffectTo(0.2f, animate_in_duration, Easing.OutQuint);
            }
            else
            {
                main.FadeEdgeEffectTo(0, animate_out_duration, Easing.OutQuint);
                main.FadeColour(AccentColour, animate_out_duration, Easing.OutQuint);
            }
        }
    }

    private readonly Bindable<bool> current = new Bindable<bool>();

    public Bindable<bool> Current
    {
        get => current;
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            current.UnbindBindings();
            current.BindTo(value);
        }
    }

    private Color4 accentColour;

    public Color4 AccentColour
    {
        get => accentColour;
        set
        {
            accentColour = value;
            if (!Glowing)
                main.Colour = value;
        }
    }

    private Color4 glowingAccentColour;

    public Color4 GlowingAccentColour
    {
        get => glowingAccentColour;
        set
        {
            glowingAccentColour = value;
            if (Glowing)
                main.Colour = value;
        }
    }

    private Color4 glowColour;

    public Color4 GlowColour
    {
        get => glowColour;
        set
        {
            glowColour = value;

            var effect = main.EdgeEffect;
            effect.Colour = Glowing ? value : value.Opacity(0);
            main.EdgeEffect = effect;
        }
    }

    private void onCurrentValueChanged(ValueChangedEvent<bool> filled)
    {
        fill.FadeTo(filled.NewValue ? 1 : 0, 200, Easing.OutQuint);

        if (filled.NewValue)
            main.ResizeWidthTo(1, animate_in_duration, Easing.OutElasticHalf);
        else
            main.ResizeWidthTo(0.9f, animate_out_duration, Easing.OutElastic);

        main.TransformTo(nameof(BorderThickness), filled.NewValue ? 8.5f : border_width, 200, Easing.OutQuint);
    }
}
