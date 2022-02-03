using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaMonogame.Core.Game.Metier.Entites
{
    public abstract class Personnage : Entite
    {
        public Personnage(Microsoft.Xna.Framework.Game game, Texture2D texture) : base(game, texture)
        {  
        }


    }
}
