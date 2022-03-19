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
    /// <summary>
    /// Manager du jeu
    /// </summary>
    public class ZeldaMonogameGame : Game
    {
        private GraphicsDeviceManager _graphics;
        
        public DeplaceurJoueur DeplaceurJoueur { get; set; }
        public Joueur PersonnagePrincipal { get; }
        public IList<Entite> Entites { get; set; }
        

        public Map Map { get; set; }
        public IGetterInput GetterInput { get; set; }
        public Menu Menu { get; set; }

        private IMGUI _ui;
        private string userName = "";

        public SpriteBatch SpriteBatch { get; set; }


        /// <summary>
        /// Constructeur
        /// </summary>
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

            DeplaceurJoueur = new DeplaceurJoueur(this);

        }

        /// <summary>
        /// Initialisation
        /// </summary>
        protected override void Initialize()
        {
            /*_graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();*/
            IsMouseVisible = true;
            base.Initialize();
        }


        /// <summary>
        /// Charge les contenus du jeu -> map, texture des joueurs + menu
        /// </summary>
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

        /// <summary>
        /// Update appelée à chaque tour de boucle du jeu
        /// </summary>
        /// <param name="gameTime">boucle de jeu</param>
        protected override void Update(GameTime gameTime)
        {
            GuiHelper.UpdateSetup(gameTime);
            _ui.UpdateAll(gameTime);
            GuiHelper.UpdateCleanup();

            Menu.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// Dessine le jeu
        /// </summary>
        /// <param name="gameTime">boucle de jeu</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkOliveGreen);
            Menu.DrawMenu(gameTime);
            base.Draw(gameTime);
        }

        /// <summary>
        /// Change la map
        /// </summary>
        /// <param name="nameNewMap">nom de la nouvelle map</param>
        /// <param name="posJoueurOnNewMap">position du joueur sur la nouvelle map</param>
        public void ChangeMap(string nameNewMap, Vector2 posJoueurOnNewMap)
        {
            Map = new Map(this, nameNewMap);
            Map.LoadContent(GraphicsDevice, Window);

            DeplaceurJoueur.MoveEntite(posJoueurOnNewMap);
        }
    }
}
