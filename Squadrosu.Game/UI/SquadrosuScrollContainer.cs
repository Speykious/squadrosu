// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osuTK;

namespace Squadrosu.Game.UI;

public class SquadrosuScrollContainer : ScrollContainer<Drawable>
{
    public SquadrosuScrollContainer(Direction scrollDirection = Direction.Vertical)
        : base(scrollDirection)
    {
        Content.Anchor = Anchor.Centre;
        Content.Origin = Anchor.Centre;
    }

    protected override ScrollbarContainer CreateScrollbar(Direction direction)
        => new SquadrosuScrollbar(direction);

    protected class SquadrosuScrollbar : ScrollbarContainer
    {
        public SquadrosuScrollbar(Direction direction)
            : base(direction)
        {
        }

        public override void ResizeTo(float val, int duration = 0, Easing easing = Easing.None)
        {
            var size = new Vector2(4) { [(int)ScrollDirection] = val };
            this.ResizeTo(size, duration, easing);
        }
    }
}
