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

        private readonly int ZOOM = 2;

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

            var viewPort = new BoxingViewportAdapter(gameWindow, graphicsDevice, graphicsDevice.Viewport.Bounds.Width / ZOOM, graphicsDevice.Viewport.Bounds.Height / ZOOM);
            Camera = new OrthographicCamera(viewPort);

            Width = _tiledMap.Width * _tiledMap.TileWidth;
            Height = _tiledMap.Height * _tiledMap.TileHeight;
        }

        public void Update(GameTime gameTime)
        {
            MoveCamera();
            
            _tileMapRenderer.Update(gameTime);
        }

        public bool IsOnCollisionTile(ushort x, ushort y)
        {
            TiledMapTileLayer collisionsLayer = (TiledMapTileLayer) _tiledMap.GetLayer("collisions");

            return !collisionsLayer.GetTile((ushort)(x / _tiledMap.TileWidth), (ushort)(y / _tiledMap.TileHeight)).IsBlank;
        }

        private void MoveCamera()
        {
            Vector2 camPosition = Vector2.Zero;

            float persoX = _game.PersonnagePrincipal.Position.X;
            float persoY = _game.PersonnagePrincipal.Position.Y;

            float camOffSetX = Camera.BoundingRectangle.Width / 2;
            float camOffSetY = Camera.BoundingRectangle.Height / 2;

            if (persoX < camOffSetX)
            {
                camPosition.X = camOffSetX;
            }
            else if (persoX > Width - camOffSetX)
            {
                camPosition.X = Width - camOffSetX;
            }
            else
            {
                camPosition.X = persoX;
            }

            if (persoY < camOffSetY)
            {
                camPosition.Y = camOffSetY;
            }
            else if (persoY > Height - camOffSetY)
            {
                camPosition.Y = Height - camOffSetY;
            }
            else
            {
                camPosition.Y = persoY;
            }



            Camera.LookAt(camPosition);
        }

        public void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            _game.SpriteBatch.Begin();
            _tileMapRenderer.Draw(Camera.GetViewMatrix());
            _game.SpriteBatch.End();

        }
    }
}
