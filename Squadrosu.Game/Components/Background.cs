// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace Squadrosu.Game.Components;

/// <summary>
/// A background which offers blurring via a <see cref="BufferedContainer"/> on demand.
/// Mostly taken from osu!'s Background class, but slightly simplified:
/// <see href="https://github.com/ppy/osu/blob/master/osu.Game/Graphics/Backgrounds/Background.cs"/>
/// </summary>
public class Background : CompositeDrawable, IEquatable<Background>
{
    private const float blur_scale = .5f;

    public readonly Sprite Sprite;
    private readonly string textureName;
    private readonly BufferedContainer bufferedContainer;

    public Background(string textureName = @"")
    {
        this.textureName = textureName;
        RelativeSizeAxes = Axes.Both;

        AddInternal(bufferedContainer = new BufferedContainer
        {
            RelativeSizeAxes = Axes.Both,
            CacheDrawnFrameBuffer = true,
            RedrawOnScale = false,
            Child = Sprite = new Sprite
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                FillMode = FillMode.Fill,
            },
        });
    }

    [BackgroundDependencyLoader]
    private void load(TextureStore textures)
    {
        if (!string.IsNullOrEmpty(textureName))
            Sprite.Texture = textures.Get(textureName);
    }

    public Vector2 BlurSigma => bufferedContainer?.BlurSigma / blur_scale ?? Vector2.Zero;

    /// <summary>
    /// Smoothly adjusts <see cref="IBufferedContainer.BlurSigma"/> over time.
    /// </summary>
    public void BlurTo(Vector2 newBlurSigma, double duration = 0, Easing easing = Easing.None)
    {
        bufferedContainer.FrameBufferScale = newBlurSigma == Vector2.Zero ? Vector2.One : new Vector2(blur_scale);
        bufferedContainer.BlurTo(newBlurSigma * blur_scale, duration, easing);
    }

    public virtual bool Equals(Background? other)
    {
        if (other == null)
            return false;
        if (ReferenceEquals(this, other))
            return true;

        return other.GetType() == GetType()
               && other.textureName == textureName;
    }
}
