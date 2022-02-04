using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaMonogame.Core.Game.Metier.Entites
{
    public class Ennemi : Personnage
    {
        public Ennemi(Microsoft.Xna.Framework.Game game, Texture2D texture, Vector2 pos, int longueur, int hauteur) : base(game, texture, pos, longueur, hauteur)
        {
        }

        public Ennemi(Microsoft.Xna.Framework.Game game, Texture2D texture) : this(game, texture, new Vector2(0, 0), texture.Width, texture.Height)
        {
        }

        public Ennemi(Microsoft.Xna.Framework.Game game, Texture2D texture, int longueur, int hauteur) : this(game, texture, new Vector2(0, 0), longueur, hauteur)
        {
        }
    }
}
