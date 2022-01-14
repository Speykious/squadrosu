// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osuTK;
using Squadrosu.Framework;
using Squadrosu.Game.Sprites.Game;
using Squadrosu.Game.UI;

namespace Squadrosu.Game.Screens;

public class SquadrosuGameScreen : SquadrosuScreen
{
    private readonly Background background;
    private readonly DrawableBoard drawableBoard;
    private readonly Framework.Game game;

    private readonly WinOverlay winOverlay;

    public SquadrosuGameScreen()
    {
        game = new(Player.White);
        winOverlay = new WinOverlay();

        InternalChildren = new Drawable[]
        {
            background = new Background(@"default_background")
            {
                Blur = 10,
                Dim = 10,
            },
            drawableBoard = new DrawableBoard(game.Board)
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
            },
            winOverlay,
        };

        drawableBoard.EnableWhiteInput.Value = true;
        drawableBoard.EnableBlackInput.Value = false;
        drawableBoard.OnPieceClicked += onPieceClickedEventHandler;
    }

    [BackgroundDependencyLoader]
    private void load(Settings settings)
    {
        settings.GameBackground.BindValueChanged(onBackgroundChange, true);
    }

    private void onBackgroundChange(ValueChangedEvent<BackgroundConfig> e)
    {
        BackgroundConfig config = e.NewValue;
        background.BlurTo(new Vector2(config.Blur), 200, Easing.OutQuint);
        background.DimTo(config.Dim, 200, Easing.OutQuint);
    }

    private void onPieceClickedEventHandler(object? sender, PieceClickedEventArgs e)
    {
        game.Move(e.Piece);

        switch (game.State)
        {
            case GameState.Playing:
                bool isWhite = game.CurrentPlayer == Player.White;
                drawableBoard.EnableWhiteInput.Value = isWhite;
                drawableBoard.EnableBlackInput.Value = !isWhite;
                break;
            case GameState.WhiteWon:
                drawableBoard.DisplayWin(Player.White);
                winOverlay.Winner = Player.White;
                winOverlay.ToggleVisibility();
                break;
            case GameState.BlackWon:
                drawableBoard.DisplayWin(Player.Black);
                winOverlay.Winner = Player.Black;
                winOverlay.ToggleVisibility();
                break;
        }
    }

    protected override void OnExit()
    {
        // TODO: add confirmation overlay

        base.OnExit();
    }
}
