// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osuTK;

namespace Squadrosu.Game.UI.Settings;

public class PercentageSettingSlider : Container<Drawable>
{
    public LocalisableString Label { get; set; }
    private SpriteText? percentage;
    private SquadrosuSliderBar? slider;

    public PercentageSettingSlider() : base()
    {
        RelativeSizeAxes = Axes.X;
        AutoSizeAxes = Axes.Y;
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        Child = new FillFlowContainer
        {
            Origin = Anchor.Centre,
            Anchor = Anchor.Centre,
            RelativeSizeAxes = Axes.X,
            AutoSizeAxes = Axes.Y,
            Direction = FillDirection.Vertical,
            Spacing = new Vector2(10),
            Children = new Drawable[]
            {
                new FillFlowContainer
                {
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Direction = FillDirection.Horizontal,
                    Children = new[]
                    {
                        new Container
                        {
                            Origin = Anchor.Centre,
                            Anchor = Anchor.Centre,
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Width = .5f,
                            Child = new SpriteText
                            {
                                Origin = Anchor.CentreLeft,
                                Anchor = Anchor.CentreLeft,
                                Text = Label,
                                Font = SquadrosuFont.Default.With(size: 42),
                            }
                        },
                        new Container
                        {
                            Origin = Anchor.Centre,
                            Anchor = Anchor.Centre,
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Width = .5f,
                            Child = percentage = new SpriteText
                            {
                                Origin = Anchor.CentreRight,
                                Anchor = Anchor.CentreRight,
                                Text = "0%",
                                Font = SquadrosuFont.Default.With(size: 42),
                            }
                        },
                    },
                },
                slider = new SquadrosuSliderBar
                {
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre,
                    RelativeSizeAxes = Axes.X,
                },
            },
        };

        slider.Current.ValueChanged += (e) => percentage.Text = @$"{e.NewValue}%";
    }
}
