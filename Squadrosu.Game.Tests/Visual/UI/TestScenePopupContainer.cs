// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;
using osuTK.Graphics;
using Squadrosu.Game.UI;

namespace Squadrosu.Game.Tests.Visual.UI;

public class TestScenePopupContainer : SquadrosuTestScene
{
    [BackgroundDependencyLoader]
    private void load()
    {
        PopupContainer popup;
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
                popup = new PopupContainer
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    FinalSize = new Vector2(400),
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                            Colour = Color4.White.Opacity(0.3f),
                        },
                        new SpriteText
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Font = FontUsage.Default.With(size: 20),
                            Text = @"Popup Container",
                        },
                    },
                }
            },
        });

        AddStep(@"show", popup.Show);
        AddStep(@"hide", popup.Hide);
    }
}
