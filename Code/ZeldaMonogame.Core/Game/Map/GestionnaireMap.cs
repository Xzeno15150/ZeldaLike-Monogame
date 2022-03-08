using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaMonogame.Core.Game.Deplacement;
using ZeldaMonogame.Core.Game.Metier.Entites;

namespace ZeldaMonogame.Core.Game.Map
{
    class GestionnaireMap
    {
        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;
        private DeplaceurCamera _cameraManager;

        private GraphicsDevice _graphicsDevice;
        private ContentManager _content;

        public TiledMap TiledMap { get => _tiledMap; private set => _tiledMap = value; }

        public GestionnaireMap(GraphicsDevice graphicsDevice, ContentManager content)
        {
            _graphicsDevice = graphicsDevice;
            _content = content;
        }

        public void SetCameraManager(GameWindow window, PersonnagePrincipal personnagePrincipal)
        {
            _cameraManager = new DeplaceurCamera(window, _graphicsDevice, personnagePrincipal);
        }

        public void LoadMap(string name)
        {
            TiledMap = _content.Load<TiledMap>("Maps/tiledmaps/" + name);
            _tiledMapRenderer = new TiledMapRenderer(_graphicsDevice, TiledMap);

            _cameraManager.SetMapTaille(TiledMap.Width * TiledMap.TileWidth, TiledMap.Height * TiledMap.TileHeight);
        }

        public void UpdateMap(GameTime gameTime)
        {
            _tiledMapRenderer.Update(gameTime);
            _cameraManager.Deplacer(gameTime);
        }

        public void DrawMap()
        {
            _tiledMapRenderer.Draw(_cameraManager.Camera.GetViewMatrix());
        }
        

    }
}
