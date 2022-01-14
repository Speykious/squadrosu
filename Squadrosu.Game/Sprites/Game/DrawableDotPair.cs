// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;

namespace Squadrosu.Game.Sprites.Game;

public class DrawableDotPair : CompositeDrawable
{
    public DrawableDotPair()
    {
        Padding = new MarginPadding(-2);
    }

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        Texture dotTexture = textures.Get(@"board/dot");
        AddInternal(new SquadrosuColoredSprite
        {
            Anchor = Anchor.TopCentre,
            Origin = Anchor.BottomCentre,
            Texture = dotTexture,
        });
        AddInternal(new SquadrosuColoredSprite
        {
            Anchor = Anchor.BottomCentre,
            Origin = Anchor.TopCentre,
            Texture = dotTexture,
        });
    }
}
