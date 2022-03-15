using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaMonogame.Core.Game.Metier.Input;

namespace ZeldaMonogame.Core.Game.Metier.Entites
{
    public class Joueur : Personnage
    {
        public int Speed { get; set; }
        private float SCALE = 2;

        public Joueur(ZeldaMonogameGame game) : this(game, 0, 0)
        {
        }


        public Joueur(ZeldaMonogameGame game, float x, float y, int speed = 150) : base(game, x, y)
        {
            Speed = speed;
        }


        public override void LoadContent(GraphicsDevice graphicsDevice, GameWindow gameWindow)
        {
            Texture = Game.Content.Load<Texture2D>("Assets/Character/Main/idle_down3");
        }

        public override void Draw(GameTime gameTime, Vector2 screenPos)
        {
            Game.SpriteBatch.Begin();
            Game.SpriteBatch.Draw(Texture, new Vector2(screenPos.X - Texture.Width * SCALE / 2, screenPos.Y - Texture.Height * SCALE /2 ) , null, Color.White, 0f, Vector2.Zero, SCALE , SpriteEffects.None, 0f);
            Game.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
