// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osuTK;

namespace Squadrosu.Game.UI.Settings;

public class SettingContainer : Container
{
    public LocalisableString Title
    {
        get => spriteTitle.Text;
        set => spriteTitle.Text = value;
    }

    private readonly SpriteText spriteTitle;
    private readonly Container contentContainer;
    protected override Container<Drawable> Content => contentContainer;

    protected readonly Container<Drawable> TitleContainer;

    public SettingContainer()
    {
        RelativeSizeAxes = Axes.X;
        AutoSizeAxes = Axes.Y;

        InternalChildren = new Drawable[]
        {
            new CompositeBackground(20)
            {
                RelativeSizeAxes = Axes.Both,
                Color = SquadrosuColor.ButtonGray,
            },
            new FillFlowContainer
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.X,
                AutoSizeAxes = Axes.Y,
                Direction = FillDirection.Horizontal,
                Margin = new MarginPadding(20),
                Children = new Drawable[]
                {
                    TitleContainer = new FillFlowContainer
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativeSizeAxes = Axes.X,
                        AutoSizeAxes = Axes.Y,
                        Direction = FillDirection.Vertical,
                        Width = .3f,
                        Spacing = new Vector2(20),
                        Padding = new MarginPadding(20)
                        {
                            Left = 40,
                            Right = 10,
                        },
                        Child = spriteTitle = new SpriteText
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Font = SquadrosuFont.Default.With(size: 50),
                        },
                    },
                    contentContainer = new Container
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        RelativeSizeAxes = Axes.X,
                        AutoSizeAxes = Axes.Y,
                        Width = .7f,
                        Padding = new MarginPadding(20)
                        {
                            Left = 10,
                            Right = 40,
                        },
                    }
                },
            },
        };

        Title = @"Option";
    }

    [BackgroundDependencyLoader]
    private void load()
    {
    }
}
