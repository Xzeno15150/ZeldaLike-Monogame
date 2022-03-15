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

        public SettingsMenu(GraphicsDevice graphicsDevice, ZeldaMonogameGame game)
        {
            fontSystem = FontSystemFactory.Create(graphicsDevice, 2048, 2048);
            fontSystem.AddFont(TitleContainer.OpenStream("Font/source-code-pro-medium.ttf"));
            GuiHelper.Setup(game, fontSystem);
            _ui = new IMGUI();
            GuiHelper.CurrentIMGUI = _ui;
        }

        public override void Update(ZeldaMonogameGame game)
        {
            throw new NotImplementedException();
        }
    }
}
