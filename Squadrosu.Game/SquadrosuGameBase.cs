// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;
using osuTK;
using Squadrosu.Resources;

namespace Squadrosu.Game;

public class SquadrosuGameBase : osu.Framework.Game
{
    // Anything in this class is shared between the test browser and the game implementation.
    // It allows for caching global dependencies that should be accessible to tests, or changing
    // the screen scaling for all components including the test browser and framework overlays.

    protected override Container<Drawable> Content { get; }

    protected SquadrosuGameBase()
    {
        // Ensure game and tests scale with window size and screen DPI.
        base.Content.Add(Content = new DrawSizePreservingFillContainer
        {
            // You may want to change TargetDrawSize to your "default" resolution, which will decide how things scale and position when using absolute coordinates.
            TargetDrawSize = new Vector2(1920, 1080)
        });
    }

    [BackgroundDependencyLoader]
    private void load()
    {
        Resources.AddStore(new DllResourceStore(typeof(SquadrosuResources).Assembly));
        Audio.Samples.PlaybackConcurrency = 6;
    }
}
