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
    class QuitMenu : Menu
    {
        public QuitMenu(ZeldaMonogameGame gameZelda, IMGUI ui, string name)
        {
            _game = gameZelda;
            _ui = ui;
            _name = name;
        }

        public override void Update(GameTime gameTime)
        {
            MenuPanel.Push().XY = new Vector2(100, 100);
            Label.Put("Quit Menu", 30, Color.White);
            if (Button.Put("Yes", 30, Color.White).Clicked)
            {
                _game.Map.SaveEvents();
                _game.Exit();
            }

            if (Button.Put("No", 30, Color.White).Clicked) _game.Menu = new MainMenu(_game, _ui, _name);
            MenuPanel.Pop();
        }
    }
}
