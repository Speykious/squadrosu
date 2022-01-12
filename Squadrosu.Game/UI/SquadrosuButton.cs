// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using System;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Audio;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osu.Framework.Localisation;
using osu.Framework.Utils;
using osuTK;
using osuTK.Graphics;

namespace Squadrosu.Game.UI;

/// <summary>
/// Pretty button.
/// A good chunk of the code has been taken from osu!'s OsuButton class:
/// <see href="https://github.com/ppy/osu/blob/master/osu.Game/Graphics/UserInterface/OsuButton.cs"/>
/// </summary>
public abstract class SquadrosuButton : Button
{
    protected ButtonBackground? Background;
    protected SpriteText? SpriteText;
    protected override Container<Drawable> Content { get; }
    public LocalisableString Text { get; set; }
    public float TextSize { get; set; }

    public float TextShearX { get; set; }
    public float BackgroundCornerRadius { get; set; }
    public bool HasShadow { get; set; }
    public event Action? OnClicked;
    public event Action? OnHovered;


    private Color4 backgroundColor;
    public Color4 BackgroundColor
    {
        get => backgroundColor;
        set
        {
            backgroundColor = value;
            Background?.FadeColour(value);
        }
    }

    protected DrawableSample? SampleHover;
    protected DrawableSample? SampleClick;

    public SquadrosuButton()
    {
        Anchor = Anchor.Centre;
        Origin = Anchor.Centre;
        Width = 250;
        Height = 100;
        TextShearX = 0f;
        TextSize = 50f;
        BackgroundCornerRadius = 0f;
        HasShadow = true;

        Content = new Container
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.Both,
            Masking = false,
        };

        Enabled.BindValueChanged(enabledChanged, true);
        Enabled.Value = true;
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        AddInternal(Content);

        Add(Background = new ButtonBackground(BackgroundCornerRadius)
        {
            Color = Color4Extensions.FromHex(@"323232"),
            HasShadow = HasShadow,
        });
        Add(SpriteText = new SpriteText
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Shear = new Vector2(TextShearX, 0),
            Padding = new MarginPadding(20),
            Font = FontUsage.Default.With(size: TextSize),
            Text = Text,
        });

        Enabled.ValueChanged += enabledChanged;
        Enabled.TriggerChange();
    }

    protected override bool OnClick(ClickEvent e)
    {
        if (Enabled.Value)
        {
            if (SampleClick != null)
            {
                double range = .08;
                SampleClick.Frequency.Value = 1 + RNG.NextDouble(range) - range / 2;
                SampleClick.Play();
            }
            Background?.FlashColour(Color4.White, 200);
            OnClicked?.Invoke();
        }

        return base.OnClick(e);
    }

    protected override bool OnHover(HoverEvent e)
    {
        if (Enabled.Value)
        {
            if (SampleHover != null)
            {
                double range = .08;
                SampleHover.Frequency.Value = 1 + RNG.NextDouble(range) - range / 2;
                SampleHover.Play();
            }
            OnHovered?.Invoke();
        }

        return base.OnHover(e);
    }

    protected override bool OnMouseDown(MouseDownEvent e)
    {
        Content.ScaleTo(0.9f, 4000, Easing.OutQuint);
        return base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseUpEvent e)
    {
        Content.ScaleTo(1, 1000, Easing.OutElastic);
        base.OnMouseUp(e);
    }

    private void enabledChanged(ValueChangedEvent<bool> e)
    {
        this.FadeColour(e.NewValue ? Color4.White : Color4.Gray, 200, Easing.OutQuint);
    }
}
