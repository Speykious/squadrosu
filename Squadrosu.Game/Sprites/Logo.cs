// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace Squadrosu.Game.Sprites;

public class Logo : Sprite
{
    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        Texture = textures.Get(@"logo/squadrosu_logo");
    }
}
