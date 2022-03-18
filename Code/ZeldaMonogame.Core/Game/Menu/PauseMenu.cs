using Apos.Gui;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaMonogame.Core.Game.Menu
{
    class PauseMenu : Menu
    {

        public PauseMenu(ZeldaMonogameGame gameZelda, IMGUI ui, string name, bool isPlaying)
        {
            _game = gameZelda;
            _ui = ui;
            _name = name;
            _isPlaying = isPlaying;
        }

        public override void Update(GameTime gameTime)
        {
            MenuPanel.Push().XY = new Vector2(100, 100); //Dispose en vertical les éléments suivant
            Label.Put("Pause Menu", 30, Color.White);
            if (Button.Put("Continue", 30, Color.White).Clicked) _game.Menu = new PlayingMenu(_game, _ui, _name);
            if (Button.Put("Settings", 30, Color.White).Clicked) _game.Menu = new SettingsMenu(_game, _ui, _name) ;
            if (Button.Put("Back to menu", 30, Color.White).Clicked) _game.Menu = new MainMenu(_game, _ui, _name);
            MenuPanel.Pop(); //Récupère le click de l'utilisateur
        }
    }
}
