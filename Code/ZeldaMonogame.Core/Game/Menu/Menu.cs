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
    /// <summary>
    /// Représente un menu
    /// </summary>
    public abstract class Menu
    {
        protected ZeldaMonogameGame _game; //manager du jeu
        protected IMGUI _ui; 
        protected string _name; //nom de l'utilisateur, initialiser à ""

        
        /// <summary>
        /// Update le menu à chaque boucle de jeu
        /// </summary>
        /// <param name="gameTime">boucle de jeu</param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Dessine le menu à chaque boucle de jeu
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void DrawMenu(GameTime gameTime)
        {
            _ui.Draw(gameTime);
        }
    }
}
