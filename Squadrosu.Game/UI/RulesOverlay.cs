// Copyright (c) SquadroCorp
// This file is part of Squadrosu!.
// Squadrosu! is licensed under the GPL v3. See LICENSE.md for details.

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Localisation;

namespace Squadrosu.Game.UI.Settings;

public class RulesOverlay : SettingsOverlay
{
    private readonly TextFlowContainer text;

    public RulesOverlay() : base()
    {
        Title = "Règles";

        text = new TextFlowContainer
        {
            Anchor = Anchor.Centre,
            Origin = Anchor.Centre,
            RelativeSizeAxes = Axes.X,
            AutoSizeAxes = Axes.Y,
            TextAnchor = Anchor.TopCentre,
        };

        header("Principe et but du jeu");
        paragraph("Chaque joueur va, à tour de rôles, avancer une de ses pièces du nombre de cases indiqué sur son point de départ : 1, 2 ou 3 cases. Une pièce qui termine une traversée est retournée et se dirige ensuite vers son point de départ initial. Quand un joueur a ramené 4 de ses 5 pions, il a gagné la partie. Mais attention, les chemins de vos pièces se croisent avec ceux de votre adversaire, et dès qu'une pièce passe dessus une pièce adverse, celle-ci retourne à son point de départ.");

        header("Point de départ");
        paragraph("Le point de départ correspond à la case de départ de la direction. Il s'agit donc de la case départ si le pion est sur le chemin aller, et la case de retournement si celle-ci est sur le chemin de retour.");

        header("Croisement de 2 pions");
        paragraph("Si un pion croise un ou plusieurs pions adverses durant son déplacement à un tour donné, il devra s'arrêter à la première case libre après le premier pion rencontré, quelque soit le nombre de cases qu'il lui reste à parcourir. Le pion adverse rencontré devra retourner au point de départ de sa direction.");

        header("Comment jouer");
        paragraph("Le joueur clique sur le pion qu'il souhaite jouer lorsque c'est son tour, et les règles de Squadro s'appliqueront automatiquement.");

        Child = text;
    }

    private void header(LocalisableString s)
    {
        text.AddText($"\n\n{s}", (t) =>
        {
            t.UseFullGlyphHeight = true;
            t.Font = SquadrosuFont.Default.With(size: 69, weight: FontWeight.Bold);
        });
    }

    private void paragraph(string s)
    {
        text.AddParagraph(s, (t) =>
        {
            t.UseFullGlyphHeight = true;
            t.Font = SquadrosuFont.Default.With(size: 42, weight: FontWeight.Regular);
        });
    }
}
