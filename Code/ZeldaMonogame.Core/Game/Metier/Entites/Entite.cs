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

        protected Vector2 _position;
        protected Texture2D _texture;

        public Entite(Microsoft.Xna.Framework.Game game, Texture2D texture) : base(game)
        {
            _game = game;
            _texture = texture;
            _position = new Vector2(0, 0);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
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

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(_texture,_position,Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
