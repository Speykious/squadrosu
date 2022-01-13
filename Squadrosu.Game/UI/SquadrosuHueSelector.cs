// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.UserInterface;

namespace Squadrosu.Game.UI;

/// <summary>
/// A slider bar where its value can be adjusted by dragging the nub.
/// </summary>
public class SquadrosuHueSelector : SliderBar<int>
{
    private Drawable? nub;
    public Bindable<int> Hue => Current;

    public SquadrosuHueSelector() : base()
    {
        Current = new BindableInt
        {
            Value = 0,
            Default = 0,
            MinValue = 0,
            MaxValue = 360,
        };

        RelativeSizeAxes = Axes.X;
        Height = 42;

        AddInternal(new Container
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Masking = true,
            CornerRadius = 10f,
            RelativeSizeAxes = Axes.Both,
            Child = new HueSelectorBackground
            {
                RelativeSizeAxes = Axes.Both
            },
        });
    }

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        var pointerTexture = textures.Get(@"hue_pointer_half");
        pointerTexture.ScaleAdjust = 1f;

        AddInternal(new Container
        {
            Origin = Anchor.CentreLeft,
            Anchor = Anchor.CentreLeft,
            RelativeSizeAxes = Axes.Both,
            Child = nub = new Container
            {
                Padding = new MarginPadding(-10),
                RelativeSizeAxes = Axes.Y,
                Origin = Anchor.Centre,
                Anchor = Anchor.CentreLeft,
                Children = new Drawable[]
                {
                    new Sprite
                    {
                        Origin = Anchor.Centre,
                        Anchor = Anchor.TopCentre,
                        TextureRelativeSizeAxes = Axes.Both,
                        Texture = pointerTexture,
                    },
                    new Sprite
                    {
                        Origin = Anchor.Centre,
                        Anchor = Anchor.BottomCentre,
                        Texture = pointerTexture,
                        Rotation = 180,
                    },
                },
            },
        });
    }

    private bool hasInitialWidth;
    protected override void UpdateValue(float value)
    {
        double duration = hasInitialWidth ? 200 : 0;
        Easing easing = Easing.OutQuint;
        nub?.MoveToX(value * DrawWidth, duration, easing);
        nub?.FadeColour(Colour4.FromHSV(value, 1, 1), duration, easing);
        hasInitialWidth = true;
    }
}
