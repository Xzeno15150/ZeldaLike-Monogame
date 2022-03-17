using Apos.Gui;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaMonogame.Core.Game.Metier.Entites;

namespace ZeldaMonogame.Core.Game.Menu
{
    class PlayingMenu : Menu
    {
        public PlayingMenu(ZeldaMonogameGame gameZelda, IMGUI ui)
        {
            game = gameZelda;
            _ui = ui;
        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Exit();
            game.Map.Update(gameTime);

            foreach (Entite e in game.Entites)
            {
                e.Update(gameTime);
            }
        }

        public override void DrawMenu(GameTime gameTime)
        {
            game.Map.Draw(gameTime, game.GraphicsDevice);
            foreach (Entite e in game.Entites)
            {
                e.Draw(gameTime);
            }
        }
    }
}
