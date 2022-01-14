// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Extensions.Color4Extensions;
using osuTK.Graphics;

namespace Squadrosu.Game.UI;

public static class SquadrosuColor
{
    public static Color4 Gray(float amt) => new Color4(amt, amt, amt, 1f);
    public static Color4 Gray(byte amt) => new Color4(amt, amt, amt, 0xff);
    public static Color4 Hex(string hex) => Color4Extensions.FromHex(hex);
    public static Color4 Hue(int hue) => Color4Extensions.FromHSV(hue, .8f, 1f);

    public static Color4 ButtonGray => Gray(0x32);
}
