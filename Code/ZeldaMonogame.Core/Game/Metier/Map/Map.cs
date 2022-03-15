﻿using Microsoft.Xna.Framework;
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
using ZeldaMonogame.Core.Game.Metier.Events;

namespace ZeldaMonogame.Core.Game.Metier.Map
{
    public class Map
    {
        private TiledMap _tiledMap;
        private TiledMapRenderer _tileMapRenderer;

        private ZeldaMonogameGame _game;

        private List<Event> _mapEvents;

        private readonly int ZOOM = 2;

        public int Height { get; private set; }
        public int Width { get; private set; }

        public string Name { get; set; }

        public OrthographicCamera Camera { get; set; }
           
        public Map(ZeldaMonogameGame game, string name, List<Event> events)
        {
            _game = game;
            Name = name;
            _mapEvents = events;
        }

        public Map(ZeldaMonogameGame game, string name) : this(game, name, new List<Event>()) { }


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
            _tileMapRenderer.Update(gameTime);
        }

        public bool IsOnCollisionTile(ushort x, ushort y)
        {
            TiledMapTileLayer collisionsLayer = (TiledMapTileLayer) _tiledMap.GetLayer("collisions");

            return !collisionsLayer.GetTile((ushort)(x / _tiledMap.TileWidth), (ushort)(y / _tiledMap.TileHeight)).IsBlank;
        }

        public void MoveCamera(Vector2 position)
        {
            Vector2 camPosition = Vector2.Zero;

            float x = position.X;
            float y = position.Y;

            float camOffSetX = Camera.BoundingRectangle.Width / 2;
            float camOffSetY = Camera.BoundingRectangle.Height / 2;

            if (x < camOffSetX)
            {
                camPosition.X = camOffSetX;
            }
            else if (x > Width - camOffSetX)
            {
                camPosition.X = Width - camOffSetX;
            }
            else
            {
                camPosition.X = x;
            }

            if (y < camOffSetY)
            {
                camPosition.Y = camOffSetY;
            }
            else if (y > Height - camOffSetY)
            {
                camPosition.Y = Height - camOffSetY;
            }
            else
            {
                camPosition.Y = y;
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
