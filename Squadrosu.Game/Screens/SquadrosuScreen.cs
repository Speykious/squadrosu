// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Graphics;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osuTK.Input;

namespace Squadrosu.Game.Screens;

/// <summary>
/// Screen with basic fluid animations and the Escape key to exit it by default.
/// </summary>
public class SquadrosuScreen : Screen
{
    private const int transition_duration = 300;
    public SquadrosuScreen()
    {
        Anchor = Anchor.Centre;
        Origin = Anchor.Centre;
    }

    protected override bool OnKeyDown(KeyDownEvent e)
    {
        if (!e.Repeat)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    OnExit();
                    return true;
            }
        };

        return base.OnKeyDown(e);
    }

    public override void OnEntering(IScreen last)
    {
        base.OnEntering(last);
        this.FadeInFromZero(transition_duration, Easing.Out);
    }

    public override bool OnExiting(IScreen next)
    {
        this.FadeOut(transition_duration, Easing.Out);
        this.ScaleTo(0.9f, transition_duration, Easing.Out);
        return base.OnExiting(next);
    }

    public override void OnSuspending(IScreen next)
    {
        base.OnSuspending(next);
        this.ScaleTo(1.1f, transition_duration, Easing.Out);
        this.FadeOut(transition_duration, Easing.Out);
    }

    public override void OnResuming(IScreen last)
    {
        base.OnResuming(last);
        this.ScaleTo(1, transition_duration, Easing.Out);
        this.FadeIn(transition_duration, Easing.Out);
    }

    protected virtual void OnExit() => this.Exit();
}
