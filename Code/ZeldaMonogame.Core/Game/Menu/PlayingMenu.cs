using Apos.Gui;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaMonogame.Core.Game.Metier.Entites;

namespace ZeldaMonogame.Core.Game.Menu
{
    /// <summary>
    /// Menu lorsqu'on joue
    /// </summary>
    class PlayingMenu : Menu
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="gameZelda">manager du jeu</param>
        /// <param name="ui"></param>
        /// <param name="name">nom de l'utilisateur</param>
        public PlayingMenu(ZeldaMonogameGame gameZelda, IMGUI ui, string name)
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                _game.Menu = new MainMenu(_game, _ui, _name);
            
           
            _game.Map.Update(gameTime); //update la map
            _game.DeplaceurJoueur.Update(gameTime); //déplace le joueur
            foreach (Entite e in _game.Entites)
            {
                e.Update(gameTime); //appuie le update de chaque entité du jeu
            }
        }

        /// <summary>
        /// Dessine le menu
        /// </summary>
        /// <param name="gameTime"></param>
        public override void DrawMenu(GameTime gameTime)
        {
            _game.Map.Draw(gameTime, _game.GraphicsDevice); //dessine la map
            foreach (Entite e in _game.Entites) //dessine les entités
            {
                e.Draw(gameTime);
            }
        }
    }
}
