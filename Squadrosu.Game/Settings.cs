// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Bindables;

namespace Squadrosu.Game;

/// <summary>
/// Struct containing all the settings that can be saved between 2 instances of the Squadrosu game.
/// </summary>
public struct Settings
{
    public Bindable<float> Hue { get; set; }
    public Bindable<BackgroundConfig> MenuBackground { get; set; }
    public Bindable<BackgroundConfig> GameBackground { get; set; }
}
