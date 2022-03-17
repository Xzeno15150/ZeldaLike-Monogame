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
    public class SettingsMenu : Menu
    {
        private float _slider = 0.5f;

        public SettingsMenu( ZeldaMonogameGame gameZelda,IMGUI ui)
        {
            game = gameZelda;
            _ui = ui;
        }

        public override void Update(GameTime gameTime)
        {
            MenuPanel.Push().XY = new Vector2(100, 100);
            Label.Put("What is your name?",30, Color.White);
            Textbox.Put(ref _name);

            bool choix1 = false, choix2 = false;
            Label.Put("Choose the device : ", 30, Color.White);

            Horizontal.Push().XY = new Vector2(10, 10);
            Checkbox.Put(ref choix1);
            Label.Put("Keyboard", 30, Color.White);
            Horizontal.Push();
            Checkbox.Put(ref choix2);
            Label.Put("Myo Armband", 30, Color.White);
            

            if (Button.Put("Back", 30, Color.White).Clicked) game.Menu = new MainMenu(game, _ui);
            MenuPanel.Pop();
        }
    }
}
