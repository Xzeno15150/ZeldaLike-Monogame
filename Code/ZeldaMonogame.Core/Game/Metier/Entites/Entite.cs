using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaMonogame.Core.Game.Metier.Entites
{
    public abstract class Entite : DrawableGameComponent, IMovable
    {
        private Vector2 _position;
        protected Texture2D Texture { get; set; }
        protected new ZeldaMonogameGame Game { get; set; }

        public Vector2 Position { get => _position; set => _position = value; }

        public Entite(ZeldaMonogameGame game, float x, float y) : base(game)
        {
            Game = game;
            _position.X = x;
            _position.Y = y;
        }

        public Entite(ZeldaMonogameGame game) : this(game, 0, 0)
        {
        }

        public abstract void LoadContent(GraphicsDevice graphicsDevice, GameWindow gameWindow);

        public abstract void Draw(GameTime gameTime, Vector2 screenPos);

    }
}
