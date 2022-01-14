// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK.Graphics;
using Squadrosu.Framework;

namespace Squadrosu.Game.Sprites.Game;

public class DrawableBoard : CompositeDrawable
{
    public readonly Board Board;

    private readonly DrawablePiece[] whiteDrawables;
    private readonly DrawablePiece[] blackDrawables;

    public DrawableBoard(Board board)
    {
        Board = board;
        whiteDrawables = new DrawablePiece[5];
        blackDrawables = new DrawablePiece[5];

        for (int i = 0; i < 5; i++)
        {
            whiteDrawables[i] = new DrawablePiece(Board.Whites[i])
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.Centre,
                RelativePositionAxes = Axes.Both,
                Rotation = 90,
                X = (i + 1) / 6f,
                Y = 0f,
            };
            blackDrawables[i] = new DrawablePiece(Board.Blacks[i])
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.Centre,
                RelativePositionAxes = Axes.Both,
                X = 0f,
                Y = (i + 1) / 6f,
            };
        }

        AutoSizeAxes = Axes.Both;
        Masking = true;
        CornerRadius = 30;
        EdgeEffect = new EdgeEffectParameters
        {
            Type = EdgeEffectType.Shadow,
            Radius = 20f,
            Colour = Color4.Black.Opacity(.5f),
        };
    }

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        int[] aDots = new[] { 1, 3, 2, 3, 1 };
        int[] bDots = new[] { 3, 1, 2, 1, 3 };

        Drawable[][] boardGridChildren = new Drawable[7][];
        for (int j = 0; j < 7; j++)
        {
            boardGridChildren[j] = new Drawable[7];

            bool jedge = j == 0 || j == 6;
            for (int i = 0; i < 7; i++)
            {
                bool iedge = i == 0 || i == 6;
                if (iedge && jedge)
                {
                    boardGridChildren[j][i] = Empty();
                }
                else if (iedge)
                {
                    boardGridChildren[j][i] = new DrawableSlot((i == 0 ? bDots : aDots)[j - 1])
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Rotation = i == 0 ? 0 : 180,
                    };
                }
                else if (jedge)
                {
                    boardGridChildren[j][i] = new DrawableSlot((j == 0 ? aDots : bDots)[i - 1])
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Rotation = j == 0 ? 90 : -90,
                    };
                }
                else
                {
                    boardGridChildren[j][i] = new DrawableCrossSlot
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    };
                }
            }
        }

        Texture zebra = textures.Get(@$"board/board_zebra_background");

        AddRangeInternal(new Drawable[]
        {
            new Sprite
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Texture = zebra,
            },
            new SquadrosuColoredSprite
            {
                Margin = new MarginPadding(-16),
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Texture = textures.Get(@$"board/board_start_line"),
            },
            new GridContainer
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.Both,
                ColumnDimensions = new[]
                {
                    new Dimension(),
                    new Dimension(),
                    new Dimension(),
                    new Dimension(),
                    new Dimension(),
                    new Dimension(),
                    new Dimension(),
                },
                RowDimensions = new[]
                {
                    new Dimension(),
                    new Dimension(),
                    new Dimension(),
                    new Dimension(),
                    new Dimension(),
                    new Dimension(),
                    new Dimension(),
                },
                Content = boardGridChildren
            },
        });

        Container pieceContainer;

        AddInternal(pieceContainer = new Container
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.Both,
            Padding = new MarginPadding(zebra.DisplayWidth / 14f),
        });

        pieceContainer.AddRange(whiteDrawables);
        pieceContainer.AddRange(blackDrawables);
    }
}
