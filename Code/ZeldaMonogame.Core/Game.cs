using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using ZeldaMonogame.Core.Game;
using MyoLib;
using ZeldaMonogame.Core.Game.Deplacement;
using ZeldaMonogame.Core.Game.Metier.Entites;

namespace ZeldaMonogame
{
    public class ZeldaMonogameGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;
        private DeplaceurCamera _cameraManager;

        private PersonnagePrincipal _personnagePrincipal;
        private DeplaceurEntite _deplaceurPersonnage;

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

            _personnagePrincipal = new PersonnagePrincipal(this, null, new Vector2(_graphics.PreferredBackBufferWidth/2, _graphics.PreferredBackBufferHeight/2), 60, 60); ;
            _deplaceurPersonnage = new DeplaceurEntite(_personnagePrincipal);
            _cameraManager = new DeplaceurCamera(Window, GraphicsDevice, _personnagePrincipal);
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

            _personnagePrincipal.SetTexture(Content.Load<Texture2D>("Assets/Character/Main/idle_down3"));
            _deplaceurPersonnage.SetMapTaille(_tiledMap.Width * _tiledMap.TileWidth, _tiledMap.Height * _tiledMap.TileHeight);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _tiledMapRenderer.Update(gameTime);
            _cameraManager.Deplacer(gameTime);

            _deplaceurPersonnage.Deplacer(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            GraphicsDevice.BlendState = BlendState.AlphaBlend;

            _tiledMapRenderer.Draw(_cameraManager.Camera.GetViewMatrix());
            _personnagePrincipal.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
