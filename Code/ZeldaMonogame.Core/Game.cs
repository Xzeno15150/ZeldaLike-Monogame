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
using FontStashSharp;
using Apos.Gui;
using MonoGame.Extended.TextureAtlases;
using Apos.Input;
using System;
using ZeldaMonogame.Core.Game.Menu;

namespace ZeldaMonogame
{
    public class ZeldaMonogameGame : Game
    {
        private GraphicsDeviceManager _graphics;
        
        public DeplaceurJoueur DeplaceurJoueur;
        public Joueur PersonnagePrincipal { get; }
        public IList<Entite> Entites { get; set; }
        

        public Map Map { get; set; }
        public IGetterInput GetterInput { get; set; }
        public Menu Menu { get; set; }

        private IMGUI _ui;
        private string userName = "Saito";

        public SpriteBatch SpriteBatch { get; set; }


        public ZeldaMonogameGame()
        {

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


            Entites = new List<Entite>();

            PersonnagePrincipal = new Joueur(this, 10*32, 11*32);
            GetterInput = new InputKeyboard();
            Entites.Add(PersonnagePrincipal);

            Map = new Map(this, "Main");

            DeplaceurJoueur = new DeplaceurJoueur(Map, PersonnagePrincipal, GetterInput);

        }

        protected override void Initialize()
        {
            /*_graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();*/
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            GraphicsDevice.BlendState = BlendState.AlphaBlend;
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (Entite e in Entites)
            {
                e.LoadContent(GraphicsDevice, Window);
            }
            Map.LoadContent(GraphicsDevice, Window);

            FontSystem fontSystem = FontSystemFactory.Create(GraphicsDevice, 2048, 2048);
            fontSystem.AddFont(TitleContainer.OpenStream("Font/source-code-pro-medium.ttf"));

            GuiHelper.Setup(this, fontSystem);
            _ui = new IMGUI();
            GuiHelper.CurrentIMGUI = _ui;

            Menu = new MainMenu(this, _ui, userName);
        }

        protected override void Update(GameTime gameTime)
        {
            GuiHelper.UpdateSetup(gameTime);
            _ui.UpdateAll(gameTime);
            GuiHelper.UpdateCleanup();

            Menu.Update(gameTime);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkOliveGreen);
            Menu.DrawMenu(gameTime);
            base.Draw(gameTime);
        }


        public void ChangeMap(string nameNewMap, Vector2 posJoueurOnNewMap)
        {
            Map = new Map(this, nameNewMap);
            Map.LoadContent(GraphicsDevice, Window);

            DeplaceurJoueur.MoveEntite(posJoueurOnNewMap);
        }
    }
}
