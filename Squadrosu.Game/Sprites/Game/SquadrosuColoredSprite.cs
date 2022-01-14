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
    private Bindable<int>? hue;

    [BackgroundDependencyLoader]
    private void load(Settings settings)
    {
        hue = settings.Hue.GetBoundCopy();
        hue.BindValueChanged(onHueChanged, true);
    }

    private void onHueChanged(ValueChangedEvent<int> hue)
    {
        Colour = SquadrosuColor.Hue(hue.NewValue);
    }
}
