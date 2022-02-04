using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaMonogame.Core.Game.Metier.Entites
{
    public class PersonnagePrincipal : Personnage
    {
        public PersonnagePrincipal(Microsoft.Xna.Framework.Game game, Texture2D texture, Vector2 pos, int longueur, int hauteur) : base(game, texture, pos, longueur, hauteur)
        {
        }
    }
}
