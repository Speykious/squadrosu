// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Bindables;

namespace Squadrosu.Game;

/// <summary>
/// Struct containing all the settings that can be saved between 2 instances of the Squadrosu game.
/// </summary>
public class Settings
{
    public Bindable<int> Hue { get; set; }
    public Bindable<BackgroundConfig> MenuBackground { get; set; }
    public Bindable<BackgroundConfig> GameBackground { get; set; }

    public Settings()
    {
        Hue = new BindableInt
        {
            Value = 0,
            Default = 0,
            MinValue = 0,
            MaxValue = 360,
        };

        MenuBackground = new Bindable<BackgroundConfig>();
        GameBackground = new Bindable<BackgroundConfig>();
    }
}
