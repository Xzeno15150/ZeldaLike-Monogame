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
    /// Menu principal
    /// </summary>
    public class MainMenu : Menu
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="gameZelda">manager du jeu</param>
        /// <param name="ui"></param>
        /// <param name="name">nom de l'utilisateur</param>
        public MainMenu(ZeldaMonogameGame gameZelda, IMGUI ui, string name)
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
            MenuPanel.Push().XY = new Vector2(100, 100); //Dispose en vertical les éléments qui suivent
            Label.Put("Main Menu", 30, Color.White);
            Label.Put($"Your name is '{_name}'", 30, Color.White);
            if (Button.Put("Play",30, Color.White).Clicked) _game.Menu = new PlayingMenu(_game, _ui, _name);
            if (Button.Put("Settings", 30, Color.White).Clicked) _game.Menu = new SettingsMenu(_game, _ui,_name); 
            if (Button.Put("Quit", 30, Color.White).Clicked) _game.Menu = new QuitMenu(_game,_ui, _name);
            MenuPanel.Pop(); //Récupère le click de l'utilisateur
        }
    }
}
