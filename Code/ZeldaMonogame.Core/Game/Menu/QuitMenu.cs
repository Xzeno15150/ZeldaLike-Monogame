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
    /// Menu de confirmation pour quitter le jeu
    /// </summary>
    class QuitMenu : Menu
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="gameZelda">manager du jeu</param>
        /// <param name="ui"></param>
        /// <param name="name">nom de l'utilisateur</param>
        public QuitMenu(ZeldaMonogameGame gameZelda, IMGUI ui, string name)
        {
            _game = gameZelda;
            _ui = ui;
            _name = name;
        }

        /// <summary>
        /// Créer le menu
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            MenuPanel.Push().XY = new Vector2(100, 100);
            Label.Put("Quit Menu", 30, Color.White);
            if (Button.Put("Yes", 30, Color.White).Clicked)
            {
                //On sauvegarde bien les évènements avant de quitter
                _game.Map.SaveEvents();
                _game.Exit();
            }

            if (Button.Put("No", 30, Color.White).Clicked) _game.Menu = new MainMenu(_game, _ui, _name);
            MenuPanel.Pop();
        }
    }
}
