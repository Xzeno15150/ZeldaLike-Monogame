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

namespace ZeldaMonogame
{
    public class ZeldaMonogameGame : Game
    {
        private GraphicsDeviceManager _graphics;
        
        public Joueur PersonnagePrincipal { get; }
        public IList<Entite> Entites { get; set; }

        public Map Map { get; set; }
        public SpriteBatch SpriteBatch { get; set; }

        public ZeldaMonogameGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            



            Entites = new List<Entite>();

            PersonnagePrincipal = new Joueur(this, new InputKeyboard());
            Entites.Add(PersonnagePrincipal);
            Map = new Map(this, "samplemap");
        }

        protected override void Initialize()
        {
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

            Map.Update(gameTime);

            foreach(Entite e in Entites)
            {
                e.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aquamarine);

            Map.Draw(gameTime, GraphicsDevice);
            /*foreach (Entite e in Entites)
            {
                e.Draw(gameTime);
            }*/

            PersonnagePrincipal.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
