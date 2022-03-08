using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using ZeldaMonogame.Core.Game;
using MyoLib;
using ZeldaMonogame.Core.Game.Metier.Entites;
using ZeldaMonogame.Core.Game.Metier.Map;

namespace ZeldaMonogame
{
    public class ZeldaMonogameGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private TiledMap _tiledMap;
        private TiledMapRenderer _tiledMapRenderer;


        public PersonnagePrincipal PersonnagePrincipal { get; set; }

        public Map Map { get; set; }

        public ZeldaMonogameGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            PersonnagePrincipal = new PersonnagePrincipal(this);
            Map = new Map(this, "samplemap");
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            _graphics.ApplyChanges();

            
            base.Initialize();
        }
        

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Map.LoadContent(GraphicsDevice, Window);
            //_deplaceurPersonnage.SetMapTaille(_tiledMap.Width * _tiledMap.TileWidth, _tiledMap.Height * _tiledMap.TileHeight);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Map.Draw(gameTime, GraphicsDevice, _spriteBatch);
            
            base.Draw(gameTime);
        }
    }
}
