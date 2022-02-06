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

        TmxMap map;
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
            //mapPart = new MapPart("Content/Maps/Map_Test.tmx");
            map= new TmxMap("Content/Maps/Map_Test.tmx");
            string name = map.Tilesets[0].Name;
            tileset = Content.Load<Texture2D>("Maps/GRASS+");

            tileWidth = map.Tilesets[0].TileWidth;
            tileHeight = map.Tilesets[0].TileHeight;

            tilesetTilesWide = tileset.Width / tileWidth;
            tilesetTilesHigh = tileset.Height / tileHeight;
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

            _spriteBatch.Begin();

            var m = map.Tilesets[0].Tiles.GetEnumerator();
            for (var i = 0; i < map.Tilesets[0].Tiles.Count; i++)
            {
                m.MoveNext();
                int gid = m.Current.Value.Id;
                //int gid = map.Tilesets[0].Tiles[i].Id;

                // Empty tile, do nothing
                if (gid == 0)
                {

                }
                else
                {
                    int tileFrame = gid - 1;
                    int column = tileFrame % tilesetTilesWide;
                    int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);

                    float x = (i % map.Width) * map.TileWidth;
                    float y = (float)Math.Floor(i / (double)map.Width) * map.TileHeight;

                    Rectangle tilesetRec = new Rectangle(tileWidth * column, tileHeight * row, tileWidth, tileHeight);

                    _spriteBatch.Draw(tileset, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec, Color.White);
                }
            }


            _spriteBatch.End();
            /*new FabriqueOgre().fabriquer(this).Draw(gameTime);
            new FabriqueZombie().fabriquer(this).Draw(gameTime);*/
            base.Draw(gameTime);
        }
    }
}
