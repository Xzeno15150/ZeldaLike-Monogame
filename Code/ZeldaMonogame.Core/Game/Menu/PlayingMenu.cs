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
        public PlayingMenu(ZeldaMonogameGame gameZelda, IMGUI ui, string name)
        {
            _game = gameZelda;
            _ui = ui;
            _name = name;
            _isPlaying = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                _game.Menu = new PauseMenu(_game, _ui, _name, _isPlaying);
            
            _game.DeplaceurJoueur.Update(gameTime);
            _game.Map.Update(gameTime);

            foreach (Entite e in _game.Entites)
            {
                e.Update(gameTime);
            }
        }

        public override void DrawMenu(GameTime gameTime)
        {
            _game.Map.Draw(gameTime, _game.GraphicsDevice);
            foreach (Entite e in _game.Entites)
            {
                e.Draw(gameTime);
            }
        }
    }
}
