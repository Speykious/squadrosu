// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Graphics;
using osu.Framework.Screens;
using osuTK;
using Squadrosu.Game.Components;
using Squadrosu.Game.Sprites;

namespace Squadrosu.Game.Screens;

public class MainMenuScreen : Screen
{
    private readonly Logo logo;
    private readonly MainMenuButton[] buttons;

    public MainMenuScreen()
    {
        InternalChildren = new Drawable[]
        {
            new Background(@"default_background")
            {
                Blur = 10,
                Dim = 10,
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
                Children = buttons = new MainMenuButton[]
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

        for (int i = 0; i < buttons.Length; i++)
            buttons[i].MoveContentToX(1000);

        using (BeginDelayedSequence(400))
        {
            logo?.MoveToX(.5f, 600, Easing.OutQuint);
            for (int i = 0; i < buttons.Length; i++)
            {
                using (BeginDelayedSequence(i * 100))
                    buttons[i].MoveContentToX(0, 600, Easing.OutQuint);
            }
        }
    }
}
