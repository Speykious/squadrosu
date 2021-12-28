// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Audio;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Utils;
using osuTK;
using osuTK.Graphics;

namespace Squadrosu.Game.UI;

public class PopupContainer : VisibilityContainer
{
    private Vector2 finalSize { get; set; }

    private readonly Container contentContainer;
    protected override Container<Drawable> Content => contentContainer;
    protected override bool StartHidden => true;

    private DrawableSample? sampleIn;
    private DrawableSample? sampleOut;

    public PopupContainer()
    {
        Masking = true;
        EdgeEffect = new EdgeEffectParameters
        {
            Type = EdgeEffectType.Shadow,
            Colour = Color4.Black.Opacity(50),
            Radius = 20f,
        };

        AddInternal(contentContainer = new Container
        {
            RelativeSizeAxes = Axes.Both,
            RelativePositionAxes = Axes.Both,
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
        });
    }

    [BackgroundDependencyLoader]
    private void load(AudioManager audio)
    {
        finalSize = Size;
        Size = new Vector2(0);
        sampleIn = new DrawableSample(audio.Samples.Get(@"dropdown-open"));
        sampleOut = new DrawableSample(audio.Samples.Get(@"dropdown-close"));
    }

    private const int pop_ms = 250;
    protected override void PopIn()
    {
        this.FadeInFromZero(pop_ms - 100, Easing.InQuint).Then()
        .ResizeHeightTo(finalSize.Y, pop_ms, Easing.InOutQuint)
        .Schedule(() => sampleOut?.Play()).Delay(pop_ms - 100)
        .ResizeWidthTo(finalSize.X, pop_ms, Easing.InOutQuint)
        .Schedule(() => sampleIn?.Play());
    }

    protected override void PopOut()
    {
        this.ResizeWidthTo(RelativeSizeAxes.HasFlag(Axes.X) ? .001f : 1f, pop_ms, Easing.InOutQuint)
        .Schedule(() => playDrawableSample(sampleIn)).Delay(pop_ms - 100)
        .ResizeHeightTo(0, pop_ms, Easing.InOutQuint)
        .Schedule(() => playDrawableSample(sampleOut)).Delay(pop_ms - 100)
        .FadeOutFromOne(pop_ms - 100, Easing.OutQuint);
    }

    private void playDrawableSample(DrawableSample? sample)
    {
        if (sample != null)
        {
            double range = .08;
            sample.Frequency.Value = 1 + RNG.NextDouble(range) - range / 2;
            sample.Play();
        }
    }
}
