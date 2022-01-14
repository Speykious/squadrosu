// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Audio;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osu.Framework.Utils;
using osuTK;
using osuTK.Graphics;
using Squadrosu.Game.UI;

namespace Squadrosu.Game.Sprites.Game;

public class DrawableSlot : CompositeDrawable
{
    public readonly int Dots;
    private Bindable<int> hue;
    private Container<Drawable>? slotContainer;

    protected DrawableSample? SampleHover;
    protected DrawableSample? SampleClick;

    public DrawableSlot(int dots)
    {
        Dots = dots;
        hue = new Bindable<int>();
        AutoSizeAxes = Axes.Both;
    }

    [BackgroundDependencyLoader]
    private void load(TextureStore textures, Settings settings, AudioManager audio)
    {
        AddInternal(slotContainer = new Container
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            AutoSizeAxes = Axes.Both,
            CornerRadius = 20,
            Colour = Color4.White.Opacity(.5f),
            Masking = true,
            Children = new[]
            {
                new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Texture = textures.Get(@$"board/slot_below"),
                },
                new SquadrosuColoredSprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Texture = textures.Get(@$"board/slot_over"),
                },
            },
        });

        DrawableDotPair[] dotPairs = new DrawableDotPair[Dots];
        for (int i = 0; i < Dots; i++)
        {
            dotPairs[i] = new DrawableDotPair
            {
                Anchor = Anchor.CentreLeft,
                Origin = Anchor.CentreLeft,
                RelativeSizeAxes = Axes.Y,
            };
        }

        AddInternal(new FillFlowContainer<DrawableDotPair>
        {
            Anchor = Anchor.CentreLeft,
            Origin = Anchor.CentreLeft,
            RelativeSizeAxes = Axes.Both,
            Spacing = new Vector2(12),
            Padding = new MarginPadding
            {
                Left = 25,
            },
            Children = dotPairs,
        });

        slotContainer.EdgeEffect = new EdgeEffectParameters
        {
            Type = EdgeEffectType.Glow,
            Roundness = 20,
        };

        hue = settings.Hue.GetBoundCopy();
        hue.BindValueChanged(onHueChanged, true);

        SampleHover = new DrawableSample(audio.Samples.Get(@"default-hover"));
        SampleClick = new DrawableSample(audio.Samples.Get(@"default-select"));
    }

    private void onHueChanged(ValueChangedEvent<int> hue)
    {
        slotContainer.TweenEdgeEffectTo(new EdgeEffectParameters
        {
            Type = EdgeEffectType.Glow,
            Radius = EdgeEffect.Radius,
            Roundness = EdgeEffect.Roundness,
            Colour = SquadrosuColor.Hue(hue.NewValue).Opacity(.5f),
        }, 200, Easing.OutQuint);
    }

    protected override bool OnHover(HoverEvent e)
    {
        if (SampleHover != null)
        {
            double range = .08;
            SampleHover.Frequency.Value = 1 + RNG.NextDouble(range) - range / 2;
            SampleHover.Play();
        }

        slotContainer.TweenEdgeEffectTo(new EdgeEffectParameters
        {
            Type = EdgeEffectType.Glow,
            Radius = 20,
            Roundness = EdgeEffect.Roundness,
            Colour = SquadrosuColor.Hue(hue.Value).Opacity(.5f),
        }, 200, Easing.OutQuint);

        return true;
    }

    protected override void OnHoverLost(HoverLostEvent e)
    {
        slotContainer.TweenEdgeEffectTo(new EdgeEffectParameters
        {
            Type = EdgeEffectType.Glow,
            Radius = 2,
            Roundness = EdgeEffect.Roundness,
            Colour = SquadrosuColor.Hue(hue.Value).Opacity(0f),
        }, 200, Easing.OutQuint);
    }

    protected override bool OnClick(ClickEvent e)
    {
        if (SampleClick != null)
        {
            double range = .08;
            SampleClick.Frequency.Value = 1 + RNG.NextDouble(range) - range / 2;
            SampleClick.Play();
        }

        slotContainer.TweenEdgeEffectTo(new EdgeEffectParameters
        {
            Type = EdgeEffectType.Glow,
            Radius = 10,
            Roundness = EdgeEffect.Roundness,
            Colour = Color4.White.Opacity(1f),
        });
        Schedule(() =>
        {
            slotContainer.TweenEdgeEffectTo(new EdgeEffectParameters
            {
                Type = EdgeEffectType.Glow,
                Radius = 20,
                Roundness = EdgeEffect.Roundness,
                Colour = SquadrosuColor.Hue(hue.Value).Opacity(.5f),
            }, 300, Easing.OutQuint);
        });
        return true;
    }
}
