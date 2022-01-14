// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using System;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Audio;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osu.Framework.Utils;
using osuTK.Graphics;
using Squadrosu.Framework;
using Squadrosu.Game.UI;

namespace Squadrosu.Game.Sprites.Game;

public class DrawablePiece : CompositeDrawable
{
    public readonly Piece Piece;
    private Bindable<int> hue;
    private Container<Drawable>? slotContainer;

    private bool enabled;
    public bool Enabled
    {
        get => enabled;
        set
        {
            this.FadeColour(SquadrosuColor.Gray(value ? 1f : .6f), 200, Easing.OutQuint);
            enabled = value;
        }
    }

    public event EventHandler<PieceClickedEventArgs>? OnClicked;

    protected DrawableSample? SampleHover;
    protected DrawableSample? SampleClick;

    public DrawablePiece(Piece piece)
    {
        Piece = piece;
        hue = new Bindable<int>();
        AutoSizeAxes = Axes.Both;
        Enabled = true;
    }

    [BackgroundDependencyLoader]
    private void load(TextureStore textures, Settings settings, AudioManager audio)
    {
        AddInternal(slotContainer = new Container
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.Both,
            CornerRadius = 20,
            Masking = true,
            EdgeEffect = new EdgeEffectParameters
            {
                Type = EdgeEffectType.Glow,
                Roundness = 20,
            }
        });

        string variant = Piece.Player == Player.White ? "white" : "black";
        AddInternal(new SquadrosuColoredSprite
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Texture = textures.Get(@$"pieces/slick_{variant}_below"),
        });
        AddInternal(new SquadrosuColoredSprite
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Texture = textures.Get(@$"pieces/slick_{variant}_over"),
        });

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

    private void glow(float radius, float opacity)
    {
        slotContainer.TweenEdgeEffectTo(new EdgeEffectParameters
        {
            Type = EdgeEffectType.Glow,
            Radius = radius,
            Roundness = EdgeEffect.Roundness,
            Colour = SquadrosuColor.Hue(hue.Value).Opacity(opacity),
        }, 200, Easing.OutQuint);
    }
    private void flash(float radius)
    {
        slotContainer.TweenEdgeEffectTo(new EdgeEffectParameters
        {
            Type = EdgeEffectType.Glow,
            Radius = radius,
            Roundness = EdgeEffect.Roundness,
            Colour = Color4.White.Opacity(1f),
        });
    }
    private void glowIn() => glow(20f, .5f);
    private void glowOut() => glow(2f, 0f);

    protected override bool OnHover(HoverEvent e)
    {
        if (Enabled)
        {
            if (SampleHover != null)
            {
                double range = .08;
                SampleHover.Frequency.Value = 1 + RNG.NextDouble(range) - range / 2;
                SampleHover.Play();
            }

            glowIn();
            return true;
        }

        return base.OnHover(e);
    }

    protected override void OnHoverLost(HoverLostEvent e)
    {
        if (Enabled)
        {
            glowOut();
            return;
        }

        base.OnHoverLost(e);
    }

    protected override bool OnClick(ClickEvent e)
    {
        if (Enabled)
        {
            if (SampleClick != null)
            {
                double range = .08;
                SampleClick.Frequency.Value = 1 + RNG.NextDouble(range) - range / 2;
                SampleClick.Play();
            }

            flash(10f);
            Schedule(glowOut);

            OnClicked?.Invoke(this, new PieceClickedEventArgs(Piece));

            return true;
        }

        return base.OnClick(e);
    }
}

public class PieceClickedEventArgs : EventArgs
{
    public Piece Piece { get; set; }

    public PieceClickedEventArgs(Piece piece)
    {
        Piece = piece;
    }
}
