// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osu.Framework.Localisation;
using osuTK;
using osuTK.Graphics;
using osuTK.Input;
using Squadrosu.Framework;

namespace Squadrosu.Game.UI;

public class WinOverlay : VisibilityContainer
{
    private readonly Box backgroundDimmer;
    private readonly SpriteText text;
    protected override bool StartHidden => true;

    public Player Winner { set => text.Text = $"Player {value} won!"; }

    public WinOverlay()
    {
        RelativePositionAxes = Axes.Both;
        RelativeSizeAxes = Axes.Both;

        AddRangeInternal(new Drawable[]
        {
            backgroundDimmer = new Box
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Alpha = 0,
                Colour = Color4.Black,
            },
            text = new SpriteText
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Text = "Currently playing",
                Font = SquadrosuFont.Default.With(size: 80, weight: FontWeight.Bold),
            },
        });
    }

    protected override void PopIn()
    {
        double duration = 500;
        Easing easing = Easing.InOutQuint;
        backgroundDimmer.FadeTo(.5f, duration, easing);
        text.FadeInFromZero(duration, easing);
    }

    protected override void PopOut()
    {
        double duration = 500;
        Easing easing = Easing.InOutQuint;
        backgroundDimmer.FadeTo(0f, duration, easing);
        text.FadeOutFromOne(duration, easing);
    }
}
