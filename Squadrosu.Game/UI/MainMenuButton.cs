// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Audio;
using osu.Framework.Input.Events;
using osuTK;

namespace Squadrosu.Game.UI;

/// <summary>
/// Pretty button for the main menu. Has heavy samples and moves a bit to the left on hover.
/// </summary>
public class MainMenuButton : SquadrosuButton
{
    public const float GlobalTextShearX = .2f;

    public MainMenuButton() : base()
    {
        Size = new Vector2(500, 150);
        TextShearX = GlobalTextShearX;
        TextSize = 80f;
        BackgroundCornerRadius = 30f;
    }

    [BackgroundDependencyLoader]
    private void load(AudioManager audio)
    {
        SampleHover = new DrawableSample(audio.Samples.Get(@"button-hover"));
        SampleClick = new DrawableSample(audio.Samples.Get(@"button-select"));

        if (SpriteText != null)
            SpriteText.Font = SpriteText.Font.With(weight: FontWeight.Bold);
    }

    /// <summary>
    /// Smoothly adjusts the horizontal position of this button's content.
    /// </summary>
    public void MoveContentToX(float destination, double duration = 0, Easing easing = Easing.None) =>
        Content.MoveToX(destination, duration, easing);

    protected override bool OnHover(HoverEvent e)
    {
        if (Enabled.Value)
            Content.MoveToX(-100, 500, Easing.OutQuint);

        return base.OnHover(e);
    }

    protected override void OnHoverLost(HoverLostEvent e)
    {
        Content.MoveToX(0, 500, Easing.OutQuint);
        base.OnHoverLost(e);
    }
}
