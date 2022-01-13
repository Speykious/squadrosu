// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Input.Events;
using osuTK;
using osuTK.Graphics;
using osuTK.Input;
using Squadrosu.Game.UI;

namespace Squadrosu.Game;

public class OptionOverlay : VisibilityContainer
{
    private readonly Box backgroundDimmer;
    private readonly PopupContainer popupContainer;
    private readonly Container<Drawable> contentContainer;
    protected override Container<Drawable> Content => contentContainer;

    public OptionOverlay()
    {
        RelativePositionAxes = Axes.Both;
        RelativeSizeAxes = Axes.Both;

        BasicSquadrosuButton OkButton;
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
            popupContainer = new PopupContainer
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                Size = new Vector2(.5f, 1f),
                Children = new Drawable[]
                {
                    new Box
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4Extensions.FromHex(@"1b1b1bbb"),
                    },
                    new Container
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativeSizeAxes = Axes.Both,
                        Children = new Drawable[]
                        {
                            // Content
                            contentContainer = new Container
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                RelativeSizeAxes = Axes.Both,
                                Padding = new MarginPadding(20),
                            },
                            // Header
                            new Container
                            {
                                Anchor = Anchor.TopCentre,
                                Origin = Anchor.TopCentre,
                                RelativeSizeAxes = Axes.X,
                                Height = 100,
                                Children = new Drawable[]
                                {
                                    new Box
                                    {
                                        RelativeSizeAxes = Axes.Both,
                                        Colour = Color4Extensions.FromHex(@"1b1b1b"),
                                    },
                                    new SpriteText
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        Text = "Options",
                                        Font = SquadrosuFont.Default.With(size: 80, weight: FontWeight.Bold),
                                    },
                                },
                            },
                            // Footer
                            new Container
                            {
                                Anchor = Anchor.BottomCentre,
                                Origin = Anchor.BottomCentre,
                                RelativeSizeAxes = Axes.X,
                                Height = 100,
                                Children = new Drawable[]
                                {
                                    new Box
                                    {
                                        RelativeSizeAxes = Axes.Both,
                                        Colour = Color4Extensions.FromHex(@"1b1b1b"),
                                    },
                                    new FillFlowContainer
                                    {
                                        Anchor = Anchor.Centre,
                                        Origin = Anchor.Centre,
                                        RelativeSizeAxes = Axes.Both,
                                        Direction = FillDirection.Horizontal,
                                        Padding = new MarginPadding(20),
                                        Spacing = new Vector2(10),
                                        Children = new Drawable[]
                                        {
                                            OkButton = new BasicSquadrosuButton
                                            {
                                                Anchor = Anchor.CentreRight,
                                                Origin = Anchor.CentreRight,
                                                Size = new Vector2(200, 70),
                                                Text = "Ok",
                                            },
                                            new SpriteText
                                            {
                                                Anchor = Anchor.CentreRight,
                                                Origin = Anchor.CentreRight,
                                                Text = @"This is a Footer",
                                                Font = SquadrosuFont.Default.With(size: 50),
                                            },
                                        },
                                    },
                                },
                            },
                        },
                    },
                },
            },
        });
        OkButton.OnClicked += Hide;
    }

    protected override void PopIn()
    {
        backgroundDimmer.FadeTo(.5f, 500, Easing.InOutQuint);
        popupContainer.Show();
    }

    protected override void PopOut()
    {
        backgroundDimmer.FadeTo(0f, 500, Easing.InOutQuint);
        popupContainer.Hide();
    }

    protected override bool OnKeyDown(KeyDownEvent e)
    {
        if (e.Key == Key.Escape)
        {
            Hide();
            return true;
        }

        return base.OnKeyDown(e);
    }
}
