// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osuTK;
using Squadrosu.Game.Components;

namespace Squadrosu.Game.Tests.Visual.Components;

public class TestSceneBackground : SquadrosuTestScene
{
    // Add visual tests to ensure correct behaviour of your game: https://github.com/ppy/osu-framework/wiki/Development-and-Testing
    // You can make changes to classes associated with the tests and they will recompile and update immediately.

    private Background? background;
    private Bindable<int> blur;

    public TestSceneBackground()
    {
        blur = new BindableNumber<int>
        {
            MinValue = 0,
            MaxValue = 100,
            Value = 0,
        };
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        background = new Background("default_background");

        blur.ValueChanged += updateBlur;

        Add(new Container
        {
            RelativeSizeAxes = Axes.Both,
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Child = background,
        });

        AddSliderStep(@"Blur", 0, 100, 0, value => blur.Value = value);
        AddStep("Set blur to 15", () => blur.Value = 15);
    }

    private void updateBlur(ValueChangedEvent<int> n)
    {
        background?.BlurTo(new Vector2(n.NewValue, n.NewValue), 500, Easing.OutQuint);
    }
}
