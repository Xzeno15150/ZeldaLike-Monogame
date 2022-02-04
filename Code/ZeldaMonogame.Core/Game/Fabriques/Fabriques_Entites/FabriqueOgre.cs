using System;
using System.Collections.Generic;
using System.Text;
using ZeldaMonogame.Core.Game.Metier.Entites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ZeldaMonogame.Core.Game.Fabriques.Fabriques_Entites
{
    public class FabriqueOgre : IFabriqueEnnnemi
    {
        private const int Longueur = 100;
        private const int Hauteur = 150;

        public Entite fabriquer(Microsoft.Xna.Framework.Game game)
        {
            return new Ennemi(game, game.Content.Load<Texture2D>("ogre_idle_anim_f0"), new Vector2(300, 200), 100, 150);
        }
    }
}
