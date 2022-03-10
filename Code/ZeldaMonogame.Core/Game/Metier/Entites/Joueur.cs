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

        private IGetterInput _getterInput;

        public Joueur(ZeldaMonogameGame game, IGetterInput getterInput) : base(game)
        {
            _getterInput = getterInput;
        }

        public override void Update(GameTime gameTime)
        {
            var seconds = gameTime.GetElapsedSeconds();
            Vector2 direction = _getterInput.GetDirection();

            Position += SPEED * direction * seconds; 
        }

        public void SetGetterInput(IGetterInput getterInput) => _getterInput = getterInput;

        public override void LoadContent(GraphicsDevice graphicsDevice, GameWindow gameWindow)
        {
            Texture = Game.Content.Load<Texture2D>("Assets/Character/Main/idle_down3");
        }

        public override void Draw(GameTime gameTime)
        {
            Game.SpriteBatch.Begin();
            Game.SpriteBatch.Draw(Texture, Position, Color.Transparent);
            // Game.Map.Camera.WorldToScreen(Position)
            Game.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
