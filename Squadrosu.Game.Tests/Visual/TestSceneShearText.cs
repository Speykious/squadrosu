// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;
using osuTK.Graphics;
using Squadrosu.Game.Sprites;

namespace Squadrosu.Game.Tests.Visual;

public class TestSceneShearText : SquadrosuTestScene
{
    private readonly Bindable<float> shearX;
    private readonly Container rectangle;
    private readonly SpriteText text;

    public TestSceneShearText()
    {
        shearX = new BindableNumber<float>
        {
            MinValue = -1f,
            MaxValue = 1f,
            Value = 0f,
        };

        var logo = new SquareLogo();

        Add(new Container
        {
            RelativeSizeAxes = Axes.Both,
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Colour = Color4.DarkSlateGray,
                },
                rectangle = new Container
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Masking = true,
                    CornerRadius = 30,
                    Width = 700,
                    Height = 200,
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Colour = Color4Extensions.FromHex(@"00000080"),
                        },
                        text = new SpriteText
                        {
                            Anchor = Anchor.Centre,
                            Origin = Anchor.Centre,
                            Text = "This text shouldn't appear sheared <.<",
                            Font = SquadrosuFont.GetFont(size: 42),
                            Padding = new MarginPadding(20),
                        },
                    },
                },
            },
        });

        shearX.BindValueChanged(updateShearX, true);

        AddSliderStep(@"Horizontal Shear", -1f, 1f, 0f, value => shearX.Value = value);
        AddStep(@"Reset Shear", () => shearX.Value = 0);
        AddStep(@"Set Shear to 0.2", () => shearX.Value = .2f);
        AddStep(@"Set Shear to 0.3", () => shearX.Value = .3f);
        AddStep(@"Set Shear to -0.2", () => shearX.Value = -.2f);
        AddStep(@"Set Shear to -0.3", () => shearX.Value = -.3f);
    }


    private void updateShearX(ValueChangedEvent<float> x)
    {
        rectangle.Shear = new Vector2(x.NewValue, 0);
        text.Shear = new Vector2(-x.NewValue, 0);
    }
}
