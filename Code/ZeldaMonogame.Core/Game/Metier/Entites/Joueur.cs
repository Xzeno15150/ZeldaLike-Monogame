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
        private int SPEED = 150;
        private float SCALE = 2;

        private IGetterInput _getterInput;

        public Joueur(ZeldaMonogameGame game, IGetterInput getterInput) : this(game, getterInput, 0, 0)
        {
            
        }


        public Joueur(ZeldaMonogameGame game, IGetterInput getterInput, float x, float y) : base(game, x, y)
        {
            _getterInput = getterInput;
        }

        public override void Update(GameTime gameTime)
        {
            var seconds = gameTime.GetElapsedSeconds();
            Vector2 direction = _getterInput.GetDirection();

            Vector2 newPos = Position + SPEED * direction * seconds;

            if(!Game.Map.IsOnCollisionTile((ushort)newPos.X, (ushort)newPos.Y) 
                && newPos.X > 0 && newPos.X < Game.Map.Width && newPos.Y > 0 && newPos.Y < Game.Map.Height)
            {
                Position = newPos;
            } 
        }

        public void SetGetterInput(IGetterInput getterInput) => _getterInput = getterInput;

        public override void LoadContent(GraphicsDevice graphicsDevice, GameWindow gameWindow)
        {
            Texture = Game.Content.Load<Texture2D>("Assets/Character/Main/idle_down3");
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 screenPos = Game.Map.Camera.WorldToScreen(Position);

            Game.SpriteBatch.Begin();
            Game.SpriteBatch.Draw(Texture, new Vector2(screenPos.X - Texture.Width * SCALE / 2, screenPos.Y - Texture.Height * SCALE /2 ) , null, Color.White, 0f, Vector2.Zero, SCALE , SpriteEffects.None, 0f);
            Game.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
