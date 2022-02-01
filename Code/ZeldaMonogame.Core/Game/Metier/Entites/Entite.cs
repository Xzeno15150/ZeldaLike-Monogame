using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaMonogame.Core.Game.Metier.Entites
{
    public abstract class Entite : DrawableGameComponent, IUpdateable
    {
        protected Microsoft.Xna.Framework.Game _game;
        protected SpriteBatch _spriteBatch;

        public Entite(Microsoft.Xna.Framework.Game game, SpriteBatch spriteBatch) : base(game)
        {
            _game = game;
            _spriteBatch = spriteBatch;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
