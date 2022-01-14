// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osuTK.Graphics;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics.Effects;
using osu.Framework.Bindables;
using Squadrosu.Game.UI;
using osu.Framework.Input.Events;

namespace Squadrosu.Game.Sprites.Game;

public class DrawableSlot : CompositeDrawable
{
    public readonly int Dots;
    private Bindable<int> hue;

    public DrawableSlot(int dots)
    {
        Dots = dots;
        AutoSizeAxes = Axes.Both;
        Colour = Color4.White.Opacity(.5f);
        Masking = true;
    }

    [BackgroundDependencyLoader]
    private void load(TextureStore textures, Settings settings)
    {
        AddInternal(new Sprite
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Texture = textures.Get(@$"board/slot_below"),
        });
        AddInternal(new SquadrosuColoredSprite
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Texture = textures.Get(@$"board/slot_over"),
        });

        EdgeEffect = new EdgeEffectParameters
        {
            Type = EdgeEffectType.Glow,
            Roundness = 20,
        };

        hue = settings.Hue.GetBoundCopy();
        hue.BindValueChanged(onHueChanged, true);
    }

    private void onHueChanged(ValueChangedEvent<int> hue)
    {
        TweenEdgeEffectTo(new EdgeEffectParameters
        {
            Type = EdgeEffectType.Glow,
            Radius = EdgeEffect.Radius,
            Roundness = EdgeEffect.Roundness,
            Colour = SquadrosuColor.Hue(hue.NewValue).Opacity(.5f),
        }, 200, Easing.OutQuint);
    }

    protected override bool OnHover(HoverEvent e)
    {
        TweenEdgeEffectTo(new EdgeEffectParameters
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
        TweenEdgeEffectTo(new EdgeEffectParameters
        {
            Type = EdgeEffectType.Glow,
            Radius = 2,
            Roundness = EdgeEffect.Roundness,
            Colour = SquadrosuColor.Hue(hue.Value).Opacity(0f),
        }, 200, Easing.OutQuint);
    }

    protected override bool OnClick(ClickEvent e)
    {
        TweenEdgeEffectTo(new EdgeEffectParameters
        {
            Type = EdgeEffectType.Glow,
            Radius = 10,
            Roundness = EdgeEffect.Roundness,
            Colour = Color4.White.Opacity(1f),
        });
        Schedule(() =>
        {
            TweenEdgeEffectTo(new EdgeEffectParameters
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
