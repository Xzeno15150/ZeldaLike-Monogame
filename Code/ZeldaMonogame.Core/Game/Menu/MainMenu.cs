using Apos.Gui;
using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaMonogame.Core.Game.Menu
{
    public class MainMenu : Menu
    {
        public MainMenu(ZeldaMonogameGame gameZelda, IMGUI ui, string name)
        {
            _game = gameZelda;
            _ui = ui;
            _name = name;
            _isPlaying = false;
        }

        public override void Update(GameTime gameTime)
        {
            MenuPanel.Push().XY = new Vector2(100, 100); //Dispose en vertical les éléments suivant
            Label.Put("Main Menu", 30, Color.White);
            Label.Put($"Your name is '{_name}'", 30, Color.White);
            if (Button.Put("Play",30, Color.White).Clicked) _game.Menu = new PlayingMenu(_game, _ui, _name);
            if (Button.Put("Settings", 30, Color.White).Clicked) _game.Menu = new SettingsMenu(_game, _ui,_name); 
            if (Button.Put("Quit", 30, Color.White).Clicked) _game.Menu = new QuitMenu(_game,_ui, _name);
            MenuPanel.Pop(); //Récupère le click de l'utilisateur
        }
    }
}
