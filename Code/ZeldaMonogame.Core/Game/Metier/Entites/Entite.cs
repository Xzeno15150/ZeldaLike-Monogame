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
    /// <summary>
    /// Représente une entité dessinable et déplacable
    /// </summary>
    public abstract class Entite : DrawableGameComponent, IMovable
    {
        private Vector2 _position;
        protected Texture2D Texture { get; set; } //son image
        protected new ZeldaMonogameGame Game { get; set; }

        public Vector2 Position { get => _position; set => _position = value; }

        /// <summary>
        /// Constructeur avec position
        /// </summary>
        /// <param name="game">manager du jeu</param>
        /// <param name="x">coordonnées en x</param>
        /// <param name="y">coordonnées en y</param>
        public Entite(ZeldaMonogameGame game, float x, float y) : base(game)
        {
            Game = game;
            _position.X = x;
            _position.Y = y;
        }

        /// <summary>
        /// Constructeur sans position
        /// </summary>
        /// <param name="game">manager du jeu</param>
        public Entite(ZeldaMonogameGame game) : this(game, 0, 0)
        {
        }

        /// <summary>
        /// Charge les contenus de l'entité
        /// </summary>
        /// <param name="graphicsDevice"></param>
        /// <param name="gameWindow"></param>
        public abstract void LoadContent(GraphicsDevice graphicsDevice, GameWindow gameWindow);

        /// <summary>
        /// Dessine le personnage
        /// </summary>
        /// <param name="gameTime">boucle de jeu</param>
        /// <param name="screenPos">position où l'afficher</param>
        public abstract void Draw(GameTime gameTime, Vector2 screenPos);

    }
}
