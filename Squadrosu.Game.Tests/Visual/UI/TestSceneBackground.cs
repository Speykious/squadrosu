// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;
using Squadrosu.Game.UI;

namespace Squadrosu.Game.Tests.Visual.UI;

public class TestSceneBackground : SquadrosuTestScene
{
    private Background? background;
    private readonly Bindable<int> blur;
    private readonly Bindable<int> dim;

    public TestSceneBackground()
    {
        blur = new BindableNumber<int>
        {
            MinValue = 0,
            MaxValue = 100,
            Value = 0,
        };
        dim = new BindableNumber<int>
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
        dim.ValueChanged += updateDim;

        Add(new Container
        {
            RelativeSizeAxes = Axes.Both,
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Child = background,
        });

        AddSliderStep(@"Blur", 0, 100, 0, value => blur.Value = value);
        AddSliderStep(@"Dim", 0, 100, 0, value => dim.Value = value);
        AddStep("Set blur=15 dim=50", () =>
        {
            blur.Value = 15;
            dim.Value = 50;
        });
        AddStep("Set blur=0 dim=0", () =>
        {
            blur.Value = 0;
            dim.Value = 0;
        });
    }

    private void updateBlur(ValueChangedEvent<int> n) =>
        background?.BlurTo(new Vector2(n.NewValue, n.NewValue), 500, Easing.OutQuint);

    private void updateDim(ValueChangedEvent<int> n) =>
        background?.DimTo(n.NewValue, 500, Easing.OutQuint);
}
