// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using osuTK;
using Squadrosu.Game.UI;

namespace Squadrosu.Game.Screens;

public class SquadrosuGameScreen : SquadrosuScreen
{
    private readonly Background background;

    public SquadrosuGameScreen()
    {
        InternalChildren = new Drawable[]
        {
            background = new Background(@"default_background")
            {
                Blur = 10,
                Dim = 10,
            },
        };
    }

    [BackgroundDependencyLoader]
    private void load(Settings settings)
    {
        settings.GameBackground.BindValueChanged(onBackgroundChange, true);
    }

    private void onBackgroundChange(ValueChangedEvent<BackgroundConfig> e)
    {
        BackgroundConfig config = e.NewValue;
        background.BlurTo(new Vector2(config.Blur), 200, Easing.OutQuint);
        background.DimTo(config.Dim, 200, Easing.OutQuint);
    }

    protected override void OnExit()
    {
        // TODO: add confirmation overlay

        base.OnExit();
    }
}
