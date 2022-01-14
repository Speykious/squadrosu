// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Graphics;
using osuTK;
using Squadrosu.Game.UI;
using Squadrosu.Game.UI.Settings;
using Squadrosu.Game.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Screens;

namespace Squadrosu.Game.Screens;

public class MainMenuScreen : SquadrosuScreen
{
    private readonly Background background;
    private readonly Logo logo;
    private readonly MainMenuButton[] buttons;

    [Resolved]
    private SquadrosuSettingsOverlay? settingsOverlay { get; set; }

    public MainMenuScreen()
    {
        MainMenuButton PlayButton;
        MainMenuButton OptionsButton;
        MainMenuButton QuitButton;
        InternalChildren = new Drawable[]
        {
            background = new Background(@"default_background")
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
                    PlayButton = new MainMenuButton { Text = "Jouer" },
                    new MainMenuButton { Text = "Règles" },
                    OptionsButton = new MainMenuButton { Text = "Options" },
                    QuitButton = new MainMenuButton { Text = "Quitter" },
                },
            },
        };
        QuitButton.OnClicked += OnExit;
        OptionsButton.OnClicked += () => settingsOverlay?.Show();
        PlayButton.OnClicked += goToGameScreen;
    }

    private void goToGameScreen()
    {
        LoadComponentAsync(new SquadrosuGameScreen(), screen =>
        {
            logo.Delay(2000).FadeOutFromOne(500, Easing.InOutQuad);
            Scheduler.AddDelayed(() =>
            {
                this.Push(screen);
            }, 3000);
        });
    }

    [BackgroundDependencyLoader]
    private void load(Settings settings)
    {
        settings.MenuBackground.BindValueChanged(onBackgroundChange, true);
    }

    private void onBackgroundChange(ValueChangedEvent<BackgroundConfig> e)
    {
        BackgroundConfig config = e.NewValue;
        background.BlurTo(new Vector2(config.Blur), 200, Easing.OutQuint);
        background.DimTo(config.Dim, 200, Easing.OutQuint);
    }

    protected override void LoadComplete()
    {
        base.LoadComplete();

        this.FadeInFromZero(700, Easing.OutQuad);

        for (int i = 0; i < buttons.Length; i++)
            buttons[i].MoveContentToX(1000);

        using (BeginDelayedSequence(500))
        {
            logo?.MoveToX(.5f, 600, Easing.OutQuint);
            for (int i = 0; i < buttons.Length; i++)
            {
                using (BeginDelayedSequence(i * 100))
                    buttons[i].MoveContentToX(0, 600, Easing.OutQuint);
            }
        }
    }

    protected override void OnExit()
    {
        // TODO: add confirmation overlay
        Game.Exit();
    }
}
