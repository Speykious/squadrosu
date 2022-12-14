// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Graphics;

namespace Squadrosu.Game.UI.Settings;

public class SquadrosuSettingsOverlay : SettingsOverlay
{
    private readonly HueSettingContainer hueSetting;
    private readonly BackgroundSettingContainer menuBackgroundSetting;
    private readonly BackgroundSettingContainer gameBackgroundSetting;

    public SquadrosuSettingsOverlay() : base()
    {
        Title = "Options";

        Children = new SettingContainer[]
        {
            hueSetting = new HueSettingContainer
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            },
            menuBackgroundSetting = new BackgroundSettingContainer
            {
                Title = "Arrière-plan Menu",
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            },
            gameBackgroundSetting = new BackgroundSettingContainer
            {
                Title = "Arrière-plan Jeu",
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            },
        };
    }

    [BackgroundDependencyLoader]
    private void load(Game.Settings settings)
    {
        hueSetting.Hue.ValueChanged += (e) =>
        {
            settings.Hue.Value = e.NewValue;
        };
        menuBackgroundSetting.Blur.ValueChanged += (e) =>
        {
            settings.MenuBackground.Value = new BackgroundConfig
            {
                Blur = e.NewValue,
                Dim = settings.MenuBackground.Value.Dim,
                Path = settings.MenuBackground.Value.Path,
            };
        };
        menuBackgroundSetting.Dim.ValueChanged += (e) =>
        {
            settings.MenuBackground.Value = new BackgroundConfig
            {
                Blur = settings.MenuBackground.Value.Blur,
                Dim = e.NewValue,
                Path = settings.MenuBackground.Value.Path,
            };
        };

        gameBackgroundSetting.Blur.ValueChanged += (e) =>
        {
            settings.GameBackground.Value = new BackgroundConfig
            {
                Blur = e.NewValue,
                Dim = settings.GameBackground.Value.Dim,
                Path = settings.GameBackground.Value.Path,
            };
        };
        gameBackgroundSetting.Dim.ValueChanged += (e) =>
        {
            settings.GameBackground.Value = new BackgroundConfig
            {
                Blur = settings.GameBackground.Value.Blur,
                Dim = e.NewValue,
                Path = settings.GameBackground.Value.Path,
            };
        };
    }
}
