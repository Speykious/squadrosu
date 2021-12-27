// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;
using Squadrosu.Game.Sprites;

namespace Squadrosu.Game.Tests.Visual;

public class TestSceneShear : SquadrosuTestScene
{
    public TestSceneShear()
    {
        var logo = new SquareLogo();

        Add(new Container
        {
            AutoSizeAxes = Axes.Both,
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Child = logo,
        });

        AddSliderStep(@"Horizontal Shear", -1f, 1f, 0f,
            value => logo.Shear = new Vector2(value, logo.Shear.Y));
        AddStep(@"Reset Shear", () => logo.Shear = new Vector2());
        AddStep(@"Set Shear to 0.2", () => logo.Shear = new Vector2(.2f, 0));
        AddStep(@"Set Shear to 0.3", () => logo.Shear = new Vector2(.3f, 0));
        AddStep(@"Set Shear to -0.2", () => logo.Shear = new Vector2(-.2f, 0));
        AddStep(@"Set Shear to -0.3", () => logo.Shear = new Vector2(-.3f, 0));
    }
}
