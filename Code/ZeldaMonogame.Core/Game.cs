using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using ZeldaMonogame.Core.Game;
using MyoLib;
using ZeldaMonogame.Core.Game.Metier.Entites;
using ZeldaMonogame.Core.Game.Metier.Map;
using ZeldaMonogame.Core.Game.Metier.Input;
using System.Collections.Generic;
using ZeldaMonogame.Core.Game.Metier.Deplaceur;
using System;

namespace ZeldaMonogame
{
    public class ZeldaMonogameGame : Game
    {
        private GraphicsDeviceManager _graphics;

        private DeplaceurJoueur _deplaceurJoueur;
        
        public Joueur PersonnagePrincipal { get; }
        public IList<Entite> Entites { get; set; }

        public MapFactory _mapFactory;
        

        public Map Map { get; set; }
        public SpriteBatch SpriteBatch { get; set; }


        public ZeldaMonogameGame()
        {
            _mapFactory = new MapFactory(this);

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            
            Entites = new List<Entite>();

            PersonnagePrincipal = new Joueur(this, 14*32, 11*32);
            Entites.Add(PersonnagePrincipal);

            Map = new Map(this, "samplemap");

            _deplaceurJoueur = new DeplaceurJoueur(Map, PersonnagePrincipal, new InputKeyboard());

        }

        protected override void Initialize()
        {
            /*_graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();*/

            base.Initialize();
        }

        protected override void LoadContent()
        {
            GraphicsDevice.BlendState = BlendState.AlphaBlend;
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (Entite e in Entites) {
                e.LoadContent(GraphicsDevice, Window);
            }
            Map.LoadContent(GraphicsDevice, Window);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _deplaceurJoueur.Update(gameTime);

            Map.Update(gameTime);

            foreach(Entite e in Entites)
            {
                e.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Map.Draw(gameTime, GraphicsDevice);
            foreach (Entite e in Entites)
            {
                e.Draw(gameTime, Map.Camera.WorldToScreen(e.Position));
            }
            base.Draw(gameTime);
        }


        public void ChangeMap(string nameNewMap, Vector2 posJoueurOnNewMap)
        {
            Map = new Map(this, nameNewMap);
            Map.LoadContent(GraphicsDevice, Window);

            _deplaceurJoueur.MoveEntite(posJoueurOnNewMap);
        }
    }
}
