// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osu.Framework.Localisation;
using osuTK;
using osuTK.Graphics;

namespace Squadrosu.Game.Components;

/// <summary>
/// Pretty button.
/// A good chunk of the code has been taken from osu!'s OsuButton class:
/// <see href="https://github.com/ppy/osu/blob/master/osu.Game/Graphics/UserInterface/OsuButton.cs"/>
/// </summary>
public class MainMenuButton : Button
{
    protected Box Background;
    protected Box Hover;
    protected SpriteText SpriteText;
    protected override Container<Drawable> Content { get; }
    public LocalisableString Text
    {
        get => SpriteText.Text;
        set => SpriteText.Text = value;
    }

    private Color4 backgroundColor;
    public Color4 BackgroundColor
    {
        get => backgroundColor;
        set
        {
            backgroundColor = value;
            Background.FadeColour(value);
        }
    }

    public const float TextShearValue = .2f;

    public MainMenuButton()
    {
        Anchor = Anchor.Centre;
        Origin = Anchor.Centre;
        Width = 500;
        Height = 120;

        Content = new Container
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.Both,
            Masking = true,
            CornerRadius = 30,
            Children = new Drawable[]
            {
                Background = new Box
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                },
                Hover = new Box
                {
                    Alpha = 0,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.White.Opacity(.05f),
                    Blending = BlendingParameters.Additive,
                    Depth = float.MinValue
                },
                SpriteText = new SpriteText
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Shear = new Vector2(TextShearValue, 0),
                    Padding = new MarginPadding(20),
                    Font = FontUsage.Default.With(size: 80),
                },
            },
        };

        BackgroundColor = Color4Extensions.FromHex(@"1b1b1b");

        Enabled.BindValueChanged(enabledChanged, true);
        Enabled.Value = true;
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        AddInternal(Content);

        Enabled.ValueChanged += enabledChanged;
        Enabled.TriggerChange();
    }


    /// <summary>
    /// Smoothly adjusts the horizontal position of this button's content.
    /// </summary>
    public void MoveContentToX(float destination, double duration = 0, Easing easing = Easing.None) =>
        Content.MoveToX(destination, duration, easing);

    protected override bool OnClick(ClickEvent e)
    {
        if (Enabled.Value)
        {
            // TODO: add select sound effect
            Background.FlashColour(Color4.White, 200);
        }

        return base.OnClick(e);
    }

    protected override bool OnHover(HoverEvent e)
    {
        if (Enabled.Value)
        {
            // TODO: add hover sound effect
            Hover.FadeIn(200, Easing.OutQuint);
            Content.MoveToX(-100, 500, Easing.OutQuint);
        }

        return base.OnHover(e);
    }

    protected override void OnHoverLost(HoverLostEvent e)
    {
        base.OnHoverLost(e);
        Hover.FadeOut(300);
        Content.MoveToX(0, 500, Easing.OutQuint);
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
