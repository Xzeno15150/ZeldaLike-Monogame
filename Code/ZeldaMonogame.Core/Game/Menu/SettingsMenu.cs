using Apos.Gui;
using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaMonogame.Core.Game.Metier.Input;

namespace ZeldaMonogame.Core.Game.Menu
{
    /// <summary>
    /// Menu des paramètres
    /// </summary>
    public class SettingsMenu : Menu
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="gameZelda">manager du jeu</param>
        /// <param name="ui"></param>
        /// <param name="name">nom de l'utilisateur</param>
        public SettingsMenu(ZeldaMonogameGame gameZelda,IMGUI ui, string name)
        {
            _game = gameZelda;
            _ui = ui;
            _name = name;
        }

        /// <summary>
        /// Créer le menu
        /// </summary>
        /// <param name="gameTime">boucle de jeu</param>
        public override void Update(GameTime gameTime)
        {
            MenuPanel.Push().XY = new Vector2(100, 100);
            Label.Put("What is your name?",30, Color.White);
            Textbox textBox = Textbox.Put(ref _name);

            bool choix1 = false, choix2 = false;
            Label.Put("Choose the device : ", 30, Color.White);

            Horizontal.Push().XY = new Vector2(10, 10);
            Checkbox.Put(ref choix1);
            Label.Put("Keyboard", 30, Color.White);
            Checkbox.Put(ref choix2);
            Label.Put("Myo Armband", 30, Color.White);

            
                if (choix1) //Si le joueur a sélectionné le clavier
                {
                    if (_game.GetterInput is not InputKeyboard) //s'il n'est pas déjà instancié
                    {
                        _game.GetterInput = new InputKeyboard();
                    }
                }

                if (choix2) //Si le joueur a sélectionné le bracelet myo
                {
                    if (_game.GetterInput is not InputMyo) //s'il n'est pas déjà instancié
                    {
                        _game.GetterInput = new InputMyo();
                    }
                }
            

            if (Button.Put("Back", 30, Color.White).Clicked)
            {
                 _game.Menu = new MainMenu(_game, _ui, _name);
            }
            _name = textBox.Text; //On récupère le nouveau pseudo
            //MenuPanel.Pop();
        }
    }
}
