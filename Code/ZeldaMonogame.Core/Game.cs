using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using ZeldaMonogame.Core.Game;
using MyoLib;
using ZeldaMonogame.Core.Game.Deplacement;
using ZeldaMonogame.Core.Game.Metier.Entites;
using ZeldaMonogame.Core.Game.Map;

namespace ZeldaMonogame
{
    public class ZeldaMonogameGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        private PersonnagePrincipal _personnagePrincipal;
        private DeplaceurEntite _deplaceurPersonnage;
        private GestionnaireMap _gestionnaireMap;

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
            _gestionnaireMap = new GestionnaireMap(GraphicsDevice,Content);
            _gestionnaireMap.SetCameraManager(Window, _personnagePrincipal);
            IsMouseVisible = false;
            base.Initialize();
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gestionnaireMap.LoadMap("samplemap");

            _personnagePrincipal.SetTexture(Content.Load<Texture2D>("Assets/Character/Main/idle_down3"));
            _deplaceurPersonnage.SetMapTaille(_gestionnaireMap.TiledMap.Width * _gestionnaireMap.TiledMap.TileWidth, _gestionnaireMap.TiledMap.Height * _gestionnaireMap.TiledMap.TileHeight);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _gestionnaireMap.UpdateMap(gameTime);
            _deplaceurPersonnage.Deplacer(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            GraphicsDevice.BlendState = BlendState.AlphaBlend;

            _gestionnaireMap.DrawMap();
            _personnagePrincipal.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
