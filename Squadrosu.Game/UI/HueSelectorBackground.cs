// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shaders;
using osu.Framework.Graphics.Shapes;

namespace Squadrosu.Game.UI;

public class HueSelectorBackground : Box, ITexturedShaderDrawable
{
    public new IShader? TextureShader { get; private set; }
    public new IShader? RoundedTextureShader { get; private set; }

    [BackgroundDependencyLoader]
    private void load(ShaderManager shaders)
    {
        TextureShader = shaders.Load(VertexShaderDescriptor.TEXTURE_2, "HueSelectorBackground");
        RoundedTextureShader = shaders.Load(VertexShaderDescriptor.TEXTURE_2, "HueSelectorBackgroundRounded");
    }
}
