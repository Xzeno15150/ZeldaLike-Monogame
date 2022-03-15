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
    public abstract class Menu
    {
        protected IMGUI _ui;
        protected FontSystem fontSystem;
        protected string _name = "Saito";
        private float _slider = 0.5f;


        
        public abstract void Update(ZeldaMonogameGame game);

        public void DrawMenu(GameTime gameTime)
        {
            _ui.Draw(gameTime)
        }
    }
}
