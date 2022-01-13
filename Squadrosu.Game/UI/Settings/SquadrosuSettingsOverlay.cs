// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;

namespace Squadrosu.Game.UI.Settings;

public class SquadrosuSettingsOverlay : SettingsOverlay
{
    public SquadrosuSettingsOverlay() : base()
    {
        Children = new SettingContainer[]
        {
            new HueSettingContainer
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            },
            new SettingContainer
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Child = new SpriteText
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Font = SquadrosuFont.Default.With(size: 50),
                    Text = @"Contained OwOptions",
                },
            },
            new BackgroundSettingContainer
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            },
        };
    }
}
