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
        public QuitMenu(ZeldaMonogameGame gameZelda, IMGUI ui)
        {
            game = gameZelda;
            _ui = ui;
        }

        public override void Update(GameTime gameTime)
        {
            MenuPanel.Push().XY = new Vector2(100, 100);
            Label.Put("Quit Menu");
            if (Button.Put("Yes", 30, Color.White).Clicked) game.Exit();
            if (Button.Put("No", 30, Color.White).Clicked) game.Menu = new MainMenu(game, _ui);
            MenuPanel.Pop();
        }
    }
}
