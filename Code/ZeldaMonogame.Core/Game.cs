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
using ZeldaMonogame.Core.Game.Menu;

namespace ZeldaMonogame
{
    public class ZeldaMonogameGame : Game
    {
        private GraphicsDeviceManager _graphics;
        
        public Joueur PersonnagePrincipal { get; }
        public IList<Entite> Entites { get; set; }

        public Map Map { get; set; }
        public Menu Menu { get; set; }

        public SpriteBatch SpriteBatch { get; set; }

        public ZeldaMonogameGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            
            Entites = new List<Entite>();

            PersonnagePrincipal = new Joueur(this, new InputKeyboard(), 14*32, 11*32);
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
            /*Map.Draw(gameTime, GraphicsDevice);
            foreach (Entite e in Entites)
            {
                e.Draw(gameTime);
            }*/
            ;
            base.Draw(gameTime);
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
