// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

namespace Squadrosu.Game;

/// <summary>
/// Struct containing all the settings that can be saved between 2 instances of the Squadrosu game.
/// </summary>
public struct Settings
{
    public float Hue { get; set; }
    public BackgroundConfig MenuBackground { get; set; }
    public BackgroundConfig GameBackground { get; set; }
}
