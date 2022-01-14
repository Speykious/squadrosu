// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics.Textures;
using Squadrosu.Framework;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics;

namespace Squadrosu.Game.Sprites.Game;

public class DrawablePiece : CompositeDrawable
{
    public readonly Piece Piece;

    public DrawablePiece(Piece piece)
    {
        Piece = piece;
        AutoSizeAxes = Axes.Both;
    }

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        string variant = Piece.Player == Player.White ? "white" : "black";
        AddInternal(new SquadrosuColoredSprite
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Texture = textures.Get(@$"pieces/slick_{variant}_below"),
        });
        AddInternal(new SquadrosuColoredSprite
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Texture = textures.Get(@$"pieces/slick_{variant}_over"),
        });
    }
}
