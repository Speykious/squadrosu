// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace Squadrosu.Game.UI.Settings;

public class BackgroundSettingContainer : SettingContainer
{
    public BackgroundSettingContainer() : base()
    {
        Title = "Arrière-plan";
        Child = new FillFlowContainer
        {
            Origin = Anchor.Centre,
            Anchor = Anchor.Centre,
            RelativeSizeAxes = Axes.X,
            AutoSizeAxes = Axes.Y,
            Spacing = new Vector2(10),
            Children = new Drawable[]
            {
                new PercentageSettingSlider
                {
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Label = "Obscurité",
                },
                new PercentageSettingSlider
                {
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Label = "Flou",
                },
            },
        };

        TitleContainer.Add(new Container
        {
            Origin = Anchor.Centre,
            Anchor = Anchor.Centre,
            Width = 160,
            Height = 90,
            Masking = true,
            CornerRadius = 15,
            Child = new Background(@"default_background")
            {
                Origin = Anchor.Centre,
                Anchor = Anchor.Centre,
            },
        });
    }
}
