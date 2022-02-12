using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ZeldaMonogame.Core.Game.Fabriques.Fabriques_Entites;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System;

namespace ZeldaMonogame
{
    public class ZeldaMonogameGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;

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
            _tiledMap = Content.Load<TiledMap>("Maps/tiledmaps/samplemap");
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap); 
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _tiledMapRenderer.Update(gameTime);
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
            GraphicsDevice.BlendState = BlendState.AlphaBlend;

            _tiledMapRenderer.Draw();

            base.Draw(gameTime);
        }
    }
}
