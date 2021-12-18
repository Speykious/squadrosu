// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Graphics;

namespace Squadrosu.Game.Tests.Visual;

public class TestSceneSpinningBox : SquadrosuTestScene
{
    // Add visual tests to ensure correct behaviour of your game: https://github.com/ppy/osu-framework/wiki/Development-and-Testing
    // You can make changes to classes associated with the tests and they will recompile and update immediately.

    public TestSceneSpinningBox()
    {
        Add(new SpinningBox
        {
            Anchor = Anchor.Centre,
        });
    }
}
