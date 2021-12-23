// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using Microsoft.Build.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using Squadrosu.Game.Components;
using Squadrosu.Game.Sprites;

namespace Squadrosu.Game.Screens;

public class MainMenuScreen : Screen
{
    private Logo? logo;

    [BackgroundDependencyLoader]
    private void load()
    {
        InternalChildren = new Drawable[]
        {
            new Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = Color4.DimGray,
            },
            logo = new Logo
            {
                Anchor = Anchor.CentreLeft,
                Origin = Anchor.CentreRight,
                RelativePositionAxes = Axes.Both,
                Position = new Vector2(-.2f, 0),
                Shear = new Vector2(.2f, 0),
            },
            new MainMenuButtons
            {
                Anchor = Anchor.CentreRight,
                Origin = Anchor.CentreRight,
                RelativePositionAxes = Axes.Both,
                Position = new Vector2(-.2f, 0),
                Children = new MainMenuButton[]
                {
                    new MainMenuButton { Text = "Jouer" },
                    new MainMenuButton { Text = "Règles" },
                    new MainMenuButton { Text = "Options" },
                    new MainMenuButton { Text = "Quitter" },
                }
            }
        };
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();

        logo?.Delay(200).MoveToX(.5f, 600, Easing.OutCirc);
    }
}
