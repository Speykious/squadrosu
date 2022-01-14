// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Sprites;
using Squadrosu.Game.UI;

namespace Squadrosu.Game.Sprites.Game;

public class SquadrosuColoredSprite : Sprite
{
    [BackgroundDependencyLoader]
    private void load(Settings settings)
    {
        settings.Hue.BindValueChanged(onHueChanged, true);
    }

    private void onHueChanged(ValueChangedEvent<int> hue)
    {
        Colour = SquadrosuColor.Hue(hue.NewValue);
    }
}
