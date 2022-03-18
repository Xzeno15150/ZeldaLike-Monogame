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
        protected ZeldaMonogameGame _game;
        protected IMGUI _ui;
        protected string _name = "";
        protected bool _isPlaying;

        
        public abstract void Update(GameTime gameTime);

        public virtual void DrawMenu(GameTime gameTime)
        {
            _ui.Draw(gameTime);
        }
    }
}
