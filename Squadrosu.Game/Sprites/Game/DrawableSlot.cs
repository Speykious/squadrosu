// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Audio;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;
using osuTK.Graphics;

namespace Squadrosu.Game.Sprites.Game;

public class DrawableSlot : CompositeDrawable
{
    public readonly int Dots;

    protected DrawableSample? SampleHover;
    protected DrawableSample? SampleClick;

    public DrawableSlot(int dots)
    {
        Dots = dots;
        AutoSizeAxes = Axes.Both;
    }

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        AddInternal(new Container
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            AutoSizeAxes = Axes.Both,
            Colour = Color4.White.Opacity(.5f),
            Children = new[]
            {
                new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Texture = textures.Get(@$"board/slot_below"),
                },
                new SquadrosuColoredSprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Texture = textures.Get(@$"board/slot_over"),
                },
            },
        });

        DrawableDotPair[] dotPairs = new DrawableDotPair[Dots];
        for (int i = 0; i < Dots; i++)
        {
            dotPairs[i] = new DrawableDotPair
            {
                Anchor = Anchor.CentreLeft,
                Origin = Anchor.CentreLeft,
                RelativeSizeAxes = Axes.Y,
            };
        }

        AddInternal(new FillFlowContainer<DrawableDotPair>
        {
            Anchor = Anchor.CentreLeft,
            Origin = Anchor.CentreLeft,
            RelativeSizeAxes = Axes.Both,
            Spacing = new Vector2(12),
            Padding = new MarginPadding
            {
                Left = 25,
            },
            Children = dotPairs,
        });
    }
}
