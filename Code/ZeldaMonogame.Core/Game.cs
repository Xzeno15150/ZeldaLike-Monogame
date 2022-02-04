using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TiledSharp;
using System;
using ZeldaMonogame.Core.Game.Fabriques.Fabriques_Entites;
using ZeldaMonogame.Core.Game.Metier.Map;

namespace ZeldaMonogame
{
    public class ZeldaMonogameGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private MapPart mapPart;
        Texture2D tileset;

        int tileWidth;
        int tileHeight;
        int tilesetTilesWide;
        int tilesetTilesHigh;
        private Rectangle perso;


        public ZeldaMonogameGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            mapPart = new MapPart("Content/Maps/Map_Test.tmx");
           /* tileset = Content.Load<Texture2D>(mapPart.Map.Tilesets[0].Name.ToString());

            tileWidth = mapPart.Map.Tilesets[0].TileWidth;
            tileHeight = mapPart.Map.Tilesets[0].TileHeight;

            tilesetTilesWide = tileset.Width / tileWidth;
            tilesetTilesHigh = tileset.Height / tileHeight;*/
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            HandleInput();
            
            

            base.Update(gameTime);
        }

        private void HandleInput()
        {
            var keys = Keyboard.GetState();

            // TODO Appeler la bonne méthode sur le déplaceur en fonction des touches appuyées
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            new FabriqueOgre().fabriquer(this).Draw(gameTime);
            new FabriqueZombie().fabriquer(this).Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
