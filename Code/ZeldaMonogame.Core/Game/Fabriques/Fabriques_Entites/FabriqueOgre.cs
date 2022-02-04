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
        public Entite fabriquer(Microsoft.Xna.Framework.Game game)
        {
            return new Ennemi(game, game.Content.Load<Texture2D>("ogre_idle_anim_f0"));
        }
    }
}
