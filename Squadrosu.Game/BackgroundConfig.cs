// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

namespace Squadrosu.Game;

/// <summary>
/// All the properties necessary to configure a background.
/// </summary>
public struct BackgroundConfig
{
    public string Path { get; set; }
    public int Blur { get; set; }
    public int Dim { get; set; }
}
