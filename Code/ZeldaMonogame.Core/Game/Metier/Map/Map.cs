using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.ViewportAdapters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaMonogame.Core.Game.Metier.Events;

namespace ZeldaMonogame.Core.Game.Metier.Map
{
    /// <summary>
    /// Manager qui gère la map et la caméra
    /// </summary>
    public class Map
    {
        private TiledMap _tiledMap; //map
        private TiledMapRenderer _tileMapRenderer;

        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        private ZeldaMonogameGame _game; //manager du jeu

        private IList<Event> _mapEvents; //collection d'évènements liés à la map

        private readonly int ZOOM = 2; //zoom de la caméra

        public int Height { get; private set; } //taille de la map
        public int Width { get; private set; } //largeur de la map

        public string Name { get; set; } //nom de la map

        public OrthographicCamera Camera { get; set; } //caméra de la map
           
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="game">manager du jeu</param>
        /// <param name="name">nom de la map</param>
        public Map(ZeldaMonogameGame game, string name)
        {
            _game = game;
            Name = name;
            //LoadEvents();
            LoadStubEvents();
        }

        /// <summary>
        /// Charge les évènements de la map à partir d'un fichier json
        /// </summary>
        private void LoadEvents()
        {
            var json = File.ReadAllText($"Content/Maps/tiledmaps/{Name}/Events.json");
            _mapEvents = JsonConvert.DeserializeObject<List<Event>>(json, settings); //charge à partir d'un fichier json
            foreach (var evt in _mapEvents)
            {
                evt.Game = _game;
            }
        }

        private void LoadStubEvents()
        {
            _mapEvents = new List<Event>();
            _mapEvents.Add(new TeleportationEvent(_game, 12, 9, Name, 0, 0, EventType.interact));
        }

        /// <summary>
        /// Sauvegarde les évènements de la map dans un fichier json
        /// </summary>
        public void SaveEvents()
        {
            var json = JsonConvert.SerializeObject(_mapEvents, settings);

            File.WriteAllText($"Content/Maps/tiledmaps/{Name}/Events.json", json);
        }


        /// <summary>
        /// Charge la map et instancie la caméra
        /// </summary>
        /// <param name="graphicsDevice"></param>
        /// <param name="gameWindow"></param>
        public void LoadContent(GraphicsDevice graphicsDevice, GameWindow gameWindow)
        {
            _tiledMap = _game.Content.Load<TiledMap>($"Maps/tiledmaps/{Name}/{Name}");
            _tileMapRenderer = new TiledMapRenderer(graphicsDevice, _tiledMap);

            var viewPort = new BoxingViewportAdapter(gameWindow, graphicsDevice, graphicsDevice.Viewport.Bounds.Width / ZOOM, graphicsDevice.Viewport.Bounds.Height / ZOOM);
            Camera = new OrthographicCamera(viewPort);

            Width = _tiledMap.Width * _tiledMap.TileWidth;
            Height = _tiledMap.Height * _tiledMap.TileHeight;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            _tileMapRenderer.Update(gameTime);
        }

        /// <summary>
        /// Renvoie true si collision avec une tuile
        /// </summary>
        /// <param name="x">coordonnées x de la tuile</param>
        /// <param name="y">coordonnées y de la tuile</param>
        /// <returns></returns>
        public bool IsOnCollisionTile(float x, float y)
        {
            TiledMapTileLayer collisionsLayer = (TiledMapTileLayer) _tiledMap.GetLayer("collisions");

            return !collisionsLayer.GetTile((ushort)(x / _tiledMap.TileWidth), (ushort)(y / _tiledMap.TileHeight)).IsBlank;
        }

        /// <summary>
        /// Vérifie s'il y a un évènement aux coordonnées (x,y), null dans le cas contraire
        /// </summary>
        /// <param name="x">coordonnées x</param>
        /// <param name="y">coordonnées y</param>
        /// <returns>Event</returns>
        public Event GetEventFromPos(float x, float y)
        {
            return _mapEvents.FirstOrDefault(e => x > e.TiledPostionOnMap.X * _tiledMap.TileWidth && x < e.TiledPostionOnMap.X * _tiledMap.TileWidth + _tiledMap.TileWidth 
                                                && y > e.TiledPostionOnMap.Y * _tiledMap.TileHeight && y < e.TiledPostionOnMap.Y * _tiledMap.TileHeight + _tiledMap.TileHeight);
           
        }

        /// <summary>
        /// Déplace la caméra à une nouvelle position
        /// </summary>
        /// <param name="position">nouvelle position</param>
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

        /// <summary>
        /// Dessine la map
        /// </summary>
        /// <param name="gameTime">boucle de jeu</param>
        /// <param name="graphicsDevice"></param>
        public void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            _game.SpriteBatch.Begin();
            _tileMapRenderer.Draw(Camera.GetViewMatrix());
            _game.SpriteBatch.End();

        }
    }
}
