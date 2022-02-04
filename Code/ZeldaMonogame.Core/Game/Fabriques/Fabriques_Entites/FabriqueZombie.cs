using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using ZeldaMonogame.Core.Game.Metier.Entites;

namespace ZeldaMonogame.Core.Game.Fabriques.Fabriques_Entites
{
    public class FabriqueZombie : IFabriqueEnnnemi
    {
        private const int Longueur = 80;
        private const int Hauteur = 60;

        public Entite fabriquer(Microsoft.Xna.Framework.Game game)
        {
            return new Ennemi(game, game.Content.Load<Texture2D>("zombie_idle_anim_f0"), Longueur, Hauteur);
        }
    }
}
