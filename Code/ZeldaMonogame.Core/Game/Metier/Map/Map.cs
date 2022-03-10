using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaMonogame.Core.Game.Metier.Map
{
    public class Map
    {
        private TiledMap _tiledMap;
        private TiledMapRenderer _tileMapRenderer;

        private ZeldaMonogameGame _game;

        public int Height { get; private set; }
        public int Width { get; private set; }

        public string Name { get; set; }

        public OrthographicCamera Camera { get; set; }
           
        public Map(ZeldaMonogameGame game, String name)
        {
            _game = game;
            Name = name;
        }

        public void LoadContent(GraphicsDevice graphicsDevice, GameWindow gameWindow)
        {
            _tiledMap = _game.Content.Load<TiledMap>($"Maps/tiledmaps/{Name}");
            _tileMapRenderer = new TiledMapRenderer(graphicsDevice, _tiledMap);

            var viewPort = new BoxingViewportAdapter(gameWindow, graphicsDevice, (int)(graphicsDevice.Viewport.Bounds.Width), (int)(graphicsDevice.Viewport.Bounds.Height));
            Camera = new OrthographicCamera(viewPort);

            Width = _tiledMap.Width * _tiledMap.TileWidth;
            Height = _tiledMap.Height * _tiledMap.TileHeight;
        }

        public void Update(GameTime gameTime)
        {
            _tileMapRenderer.Update(gameTime);

            Vector2 position = Vector2.Zero;
            //if (_game.PersonnagePrincipal.Position.X < Camera.)
            Camera.LookAt(_game.PersonnagePrincipal.Position);
            /*if (Keyboard.GetState().IsKeyDown(Keys.Up))
                Camera.ZoomIn(0.01f);
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                Camera.ZoomOut(0.01f);*/
        }

        public void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(Color.Black);
            graphicsDevice.BlendState = BlendState.AlphaBlend;

            _game.SpriteBatch.Begin();
            _tileMapRenderer.Draw(Camera.GetViewMatrix());
            _game.SpriteBatch.End();

        }
    }
}
