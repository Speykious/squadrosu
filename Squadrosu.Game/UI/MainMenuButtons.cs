// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace Squadrosu.Game.UI;

public class MainMenuButtons : FillFlowContainer<MainMenuButton>
{
    public MainMenuButtons()
    {
        Anchor = Anchor.Centre;
        Origin = Anchor.Centre;
        Direction = FillDirection.Vertical;
        Spacing = new Vector2(0, 5);
        Shear = new Vector2(-MainMenuButton.GlobalTextShearX, 0);
    }
}
