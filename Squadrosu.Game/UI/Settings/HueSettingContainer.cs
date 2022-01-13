// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace Squadrosu.Game.UI.Settings;

public class HueSettingContainer : SettingContainer
{
    public readonly Bindable<float> Hue;
    private readonly SquadrosuHueSelector selector;
    public HueSettingContainer() : base()
    {
        Title = "Couleur";
        Child = new FillFlowContainer
        {
            Origin = Anchor.Centre,
            Anchor = Anchor.Centre,
            RelativeSizeAxes = Axes.X,
            AutoSizeAxes = Axes.Y,
            Spacing = new Vector2(10),
            Children = new Drawable[]
            {
                selector = new SquadrosuHueSelector
                {
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre,
                },
            },
        };

        Hue = selector.Hue.GetBoundCopy();
    }
}
