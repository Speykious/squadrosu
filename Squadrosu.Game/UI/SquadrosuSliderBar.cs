// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Sample;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Utils;
using osuTK;

namespace Squadrosu.Game.UI;

/// <summary>
/// A slider bar where its value can be adjusted by dragging the nub.
/// </summary>
public class SquadrosuSliderBar : SliderBar<int>
{
    private Drawable? nub;

    private Sample? sample;
    private double lastSampleTime;
    private int lastSampleValue;

    public SquadrosuSliderBar() : base()
    {
        Current = new BindableInt
        {
            Value = 0,
            Default = 0,
            MinValue = 0,
            MaxValue = 100,
        };

        RelativeSizeAxes = Axes.X;
        Height = 10;

        AddInternal(new CircularContainer
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.Both,
            CornerRadius = 5f,
            Masking = true,
            Child = new Box
            {
                RelativeSizeAxes = Axes.Both,
                Colour = SquadrosuColor.SliderGray.Opacity(0x80),
            },
        });
    }

    [BackgroundDependencyLoader]
    private void load(AudioManager audio)
    {
        sample = audio.Samples.Get(@"notch-tick");

        AddInternal(new Container
        {
            Origin = Anchor.CentreLeft,
            Anchor = Anchor.CentreLeft,
            RelativeSizeAxes = Axes.Both,
            Child = nub = new Circle
            {
                Origin = Anchor.Centre,
                Anchor = Anchor.CentreLeft,
                Size = new Vector2(20),
                Colour = SquadrosuColor.SliderGray,
            },
        });
    }

    private bool hasInitialWidth;
    protected override void UpdateValue(float value)
    {
        double duration = hasInitialWidth ? 200 : 0;
        Easing easing = Easing.OutQuint;
        nub?.MoveToX(value * DrawWidth, duration, easing);
        hasInitialWidth = true;
    }

    protected override void OnUserChange(int value)
    {
        base.OnUserChange(value);
        playSample(value);
        // updateTooltipText(value);
    }

    private void playSample(int value)
    {
        if (Clock == null || Clock.CurrentTime - lastSampleTime <= 30)
            return;

        if (value.Equals(lastSampleValue))
            return;

        lastSampleValue = value;
        lastSampleTime = Clock.CurrentTime;

        if (sample != null)
        {
            var channel = sample.GetChannel();

            channel.Frequency.Value = 0.99f + RNG.NextDouble(0.02f) + NormalizedValue * 0.2f;

            // intentionally pitched down, even when hitting max.
            if (NormalizedValue == 0 || NormalizedValue == 1)
                channel.Frequency.Value -= 0.5f;

            channel.Play();
        }
    }
}
