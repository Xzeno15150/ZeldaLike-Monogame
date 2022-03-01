using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ZeldaMonogame.Core.Game.Fabriques.Fabriques_Entites;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.ViewportAdapters;
using System;
using MonoGame.Extended;
using ZeldaMonogame.Core.Game;
using MyoLib;

namespace ZeldaMonogame
{
    public class ZeldaMonogameGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;
        private CameraManager _cameraManager;

        private MyoManager allo;
        public ZeldaMonogameGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            _cameraManager = new CameraManager(Window, GraphicsDevice);
            IsMouseVisible = false;
            base.Initialize();
        }

        private void LoadMap(string name)
        {
            _tiledMap = Content.Load<TiledMap>("Maps/tiledmaps/"+name);
            _tiledMapRenderer = new TiledMapRenderer(GraphicsDevice, _tiledMap);
            _cameraManager.SetMapTaille(_tiledMap.Width * _tiledMap.TileWidth, _tiledMap.Height * _tiledMap.TileHeight);
        }
        

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadMap("samplemap");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here
            _tiledMapRenderer.Update(gameTime);
            //HandleInput();
            _cameraManager.MoveCamera(gameTime);
            base.Update(gameTime);
        }

        private void HandleInput()
        {
            var keys = Keyboard.GetState();

            // TODO Appeler la bonne méthode sur le déplaceur en fonction des touches appuyées
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            GraphicsDevice.BlendState = BlendState.AlphaBlend;

            _tiledMapRenderer.Draw(_cameraManager.Camera.GetViewMatrix());
            base.Draw(gameTime);
        }
    }
}
