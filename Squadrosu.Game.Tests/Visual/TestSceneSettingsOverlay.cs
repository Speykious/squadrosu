// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using Squadrosu.Game.UI;
using Squadrosu.Game.UI.Settings;

namespace Squadrosu.Game.Tests.Visual;

public class TestSceneSettingsOverlay : SquadrosuTestScene
{
    [BackgroundDependencyLoader]
    private void load()
    {
        SettingsOverlay overlay;
        Add(new Container
        {
            RelativeSizeAxes = Axes.Both,
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Children = new Drawable[]
            {
                new Background("default_background")
                {
                    Blur = 15,
                    Dim = 0,
                },
                overlay = new SettingsOverlay
                {
                    Children = new Drawable[]
                    {
                        new SpriteText
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Font = SquadrosuFont.Default.With(size: 50),
                            Text = @"OwOptions",
                        },
                        new SettingContainer
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Child = new SpriteText
                            {
                                Anchor = Anchor.Centre,
                                Origin = Anchor.Centre,
                                Font = SquadrosuFont.Default.With(size: 50),
                                Text = @"Contained OwOptions",
                            },
                        },
                    },
                }
            },
        });

        AddStep(@"show", overlay.Show);
        AddStep(@"hide", overlay.Hide);
    }
}