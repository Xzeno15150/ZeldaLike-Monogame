using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public String Name { get; set;  }

        public OrthographicCamera Camera { get; set; }
           
        public Map(ZeldaMonogameGame game, String name)
        {
            _game = game;
            Name = name;
        }

        public void  LoadContent(GraphicsDevice graphicsDevice, GameWindow gameWindow)
        {
            _tiledMap = _game.Content.Load<TiledMap>($"Maps/tiledmaps/{Name}");
            _tileMapRenderer = new TiledMapRenderer(graphicsDevice, _tiledMap);

            var viewPort = new BoxingViewportAdapter(gameWindow, graphicsDevice, 800, 500);
            Camera = new OrthographicCamera(viewPort);
        }

        public void Draw(GameTime gameTime, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Black);
            graphicsDevice.BlendState = BlendState.AlphaBlend;


            _tileMapRenderer.Draw(Camera.GetViewMatrix());

        }
    }
}
