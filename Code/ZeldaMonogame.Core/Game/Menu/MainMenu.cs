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
        public MainMenu(ZeldaMonogameGame gameZelda, IMGUI ui)
        {
            game = gameZelda;
            _ui = ui;
        }

        public override void Update(GameTime gameTime)
        {
            MenuPanel.Push().XY = new Vector2(100, 100); //Dispose en vertical les éléments suivant
            Label.Put("Main Menu", 30, Color.White);
            Label.Put($"Your name is '{_name}'", 30, Color.White);
            if (Button.Put("Play",30, Color.White).Clicked) game.Menu = new PlayingMenu(game, _ui);
            if (Button.Put("Settings", 30, Color.White).Clicked) game.Menu = new SettingsMenu(game, _ui); 
            if (Button.Put("Quit", 30, Color.White).Clicked) game.Menu = new QuitMenu(game,_ui);
            MenuPanel.Pop(); //Récupère le click de l'utilisateur
        }
    }
}
