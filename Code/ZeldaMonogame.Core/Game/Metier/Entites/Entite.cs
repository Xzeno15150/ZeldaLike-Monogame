using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeldaMonogame.Core.Game.Metier.Entites
{
    public abstract class Entite : DrawableGameComponent, IUpdateable, IMovable
    {
        protected Microsoft.Xna.Framework.Game _game;
        protected SpriteBatch _spriteBatch;

        protected Vector2 _position;
        protected Texture2D _texture;

        protected int _longueur;
        protected int _hauteur;

        public Vector2 Position { get => _position; set => _position = value; }

        public Entite(Microsoft.Xna.Framework.Game game, Texture2D texture, Vector2 pos, int longueur, int hauteur) : base(game)
        {
            _game = game;
            _texture = texture;
            _position = pos;
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _longueur = longueur;
            _hauteur = hauteur;
        }

        public Entite(Microsoft.Xna.Framework.Game game, Texture2D texture) : this(game, texture, new Vector2(0, 0), texture.Width, texture.Height)
        {
        }

        public Entite(Microsoft.Xna.Framework.Game game, Texture2D texture, int longueur, int hauteur) : this(game, texture, new Vector2(0, 0), longueur, hauteur)
        {
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
            _spriteBatch.Draw(_texture, _position, null, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
