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
using FontStashSharp;
using Apos.Gui;
using MonoGame.Extended.TextureAtlases;
using Apos.Input;
using System;

namespace ZeldaMonogame
{
    public class ZeldaMonogameGame : Game
    {
        private GraphicsDeviceManager _graphics;
        
        public Joueur PersonnagePrincipal { get; }
        public IList<Entite> Entites { get; set; }

        public Map Map { get; set; }
        public SpriteBatch SpriteBatch { get; set; }

        private IMGUI _ui;
        private TextureRegion2D _apos;
        private string _name = "no name";
        private float _slider = 0.5f;
        public ZeldaMonogameGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            
            Entites = new List<Entite>();

            PersonnagePrincipal = new Joueur(this, new InputMyo(), 14*32, 11*32);
            Entites.Add(PersonnagePrincipal);
            Map = new Map(this, "samplemap");
        }

        protected override void Initialize()
        {
            /*_graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();*/

            IsMouseVisible = false;
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




            FontSystem fontSystem = FontSystemFactory.Create(GraphicsDevice, 2048, 2048);
            fontSystem.AddFont(TitleContainer.OpenStream($"{Content.RootDirectory}/source-code-pro-medium.ttf"));

            GuiHelper.Setup(this, fontSystem);
            _ui = new IMGUI();
            GuiHelper.CurrentIMGUI = _ui;

            var texture = Content.Load<Texture2D>("apos");

            _apos = new TextureRegion2D(texture, 0, 0, texture.Width, texture.Height);
        }

        protected override void Update(GameTime gameTime)
        {
            if (false)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                Map.Update(gameTime);

                foreach (Entite e in Entites)
                {
                    e.Update(gameTime);
                }
            }

            GuiHelper.UpdateSetup(gameTime);

            if (_quit.Pressed())
                Exit();

            _ui.UpdateAll(gameTime);

            MenuPanel.Push().XY = new Vector2(100, 100);
            if (_menu == Menu.Main)
            {
                Label.Put("Main Menu");
                Label.Put($"Your name is '{_name}'");
                if (Button.Put("Settings").Clicked) _menu = Menu.Settings;
                if (Button.Put("Quit").Clicked) _menu = Menu.Quit;
            }
            else if (_menu == Menu.Settings)
            {
                Label.Put("What is your name?");
                Textbox.Put(ref _name);
                Slider.Put(ref _slider, 0f, 1f, 0.1f);
                Label.Put($"{Math.Round(_slider, 3)}");
                Icon.Put(_apos);
                if (Button.Put("Back").Clicked) _menu = Menu.Main;
            }
            else if (_menu == Menu.Quit)
            {
                Label.Put("Quit Menu");
                if (Button.Put("Yes").Clicked) Exit();
                if (Button.Put("No").Clicked) _menu = Menu.Main;
            }
            MenuPanel.Pop();

            GuiHelper.UpdateCleanup();
            base.Update(gameTime);
        }
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            Map.Draw(gameTime, GraphicsDevice);
            foreach (Entite e in Entites)
            {
                e.Draw(gameTime);
            }
            base.Draw(gameTime);
        }

        enum Menu
        {
            Main,
            Settings,
            Quit
        }
        Menu _menu = Menu.Main;

        ICondition _quit =
            new AnyCondition(
                new KeyboardCondition(Keys.Escape),
                new GamePadCondition(GamePadButton.Back, 0)
            );

        int _counter = 0;

    }
}
