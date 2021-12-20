// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Graphics;
using osuTK;

namespace Squadrosu.Game.Tests.Visual;

public class TestSceneShear : SquadrosuTestScene
{
    // Add visual tests to ensure correct behaviour of your game: https://github.com/ppy/osu-framework/wiki/Development-and-Testing
    // You can make changes to classes associated with the tests and they will recompile and update immediately.

    public TestSceneShear()
    {
        var floatingLogo = new FloatingLogo
        {
            Anchor = Anchor.Centre,
            CycleDuration = 2000,
        };

        Add(floatingLogo);

        AddSliderStep(@"Horizontal Shear", -1f, 1f, 0f,
            value => floatingLogo.Shear = new Vector2(value, floatingLogo.Shear.Y));
        AddStep(@"Reset Shear", () => floatingLogo.Shear = new Vector2());
    }
}
