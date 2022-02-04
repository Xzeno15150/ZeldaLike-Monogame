using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using ZeldaMonogame.Core.Game.Fabriques.Fabriques_Entites;

namespace ZeldaMonogame
{
    public class ZeldaMonogameGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Rectangle perso;


        public ZeldaMonogameGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            HandleInput();
            
            

            base.Update(gameTime);
        }

        private void HandleInput()
        {
            var keys = Keyboard.GetState();

            // TODO Appeler la bonne méthode sur le déplaceur en fonction des touches appuyées
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            new FabriqueOgre().fabriquer(this).Draw(gameTime);
            new FabriqueZombie().fabriquer(this).Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
