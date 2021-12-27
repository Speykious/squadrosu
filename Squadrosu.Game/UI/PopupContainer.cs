// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osuTK;
using osuTK.Graphics;

namespace Squadrosu.Game.UI;

public class PopupContainer : VisibilityContainer
{
    public Vector2 FinalSize { get; set; }

    private readonly Container contentContainer;
    protected override Container<Drawable> Content => contentContainer;

    protected override bool StartHidden => true;

    public PopupContainer()
    {
        Masking = true;
        EdgeEffect = new EdgeEffectParameters
        {
            Type = EdgeEffectType.Shadow,
            Colour = Color4.Black.Opacity(50),
            Radius = 20f,
        };

        FinalSize = new Vector2(640, 1080);

        AddInternal(contentContainer = new Container
        {
            Size = FinalSize,
            RelativePositionAxes = Axes.Both,
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
        });

        Size = new Vector2(0, 0);
    }

    private const int pop_ms = 400;
    protected override void PopIn()
    {
        this.FadeInFromZero(pop_ms - 100, Easing.InQuint)
        .Then().ResizeHeightTo(FinalSize.Y, pop_ms, Easing.InOutQuint)
        .Delay(pop_ms - 100).ResizeWidthTo(FinalSize.X, pop_ms, Easing.InOutQuint);
    }
    protected override void PopOut()
    {
        this.ResizeWidthTo(1, pop_ms, Easing.InOutQuint)
        .Delay(pop_ms - 100).ResizeHeightTo(0, pop_ms, Easing.InOutQuint)
        .Delay(pop_ms - 100).FadeOutFromOne(pop_ms - 100, Easing.OutQuint);
    }
}
