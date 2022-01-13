// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Graphics.Sprites;

namespace Squadrosu.Game;

public static class SquadrosuFont
{
    public static FontUsage Default => GetFont();

    public static FontUsage GetFont(float size = 14f) =>
        new FontUsage("Abel", size: size);


}

public static class SquadrosuFontExtensions
{
    public static FontUsage With(this FontUsage usage, FontWeight? weight = null, float? size = null, bool? italics = null, bool? fixedWidth = null)
        => usage.With("Abel", size, weight?.ToString(), italics, fixedWidth);
}

public enum FontWeight
{
    Regular,
    Bold,
}
