using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaMonogame.Core.Game.Metier.Entites;
using ZeldaMonogame.Core.Game.Metier.Events;
using ZeldaMonogame.Core.Game.Metier.Input;

namespace ZeldaMonogame.Core.Game.Metier.Deplaceur
{

    /// <summary>
    /// Effectue le déplacement du personnage sur la carte
    /// </summary>
    public class DeplaceurJoueur : IDeplaceurEntite
    {

        private ZeldaMonogameGame _game;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="map"> gestionnaire de la map</param>
        /// <param name="joueur"> joueur à déplacer</param>
        /// <param name="getterInput">getter pour la direction</param>
        public DeplaceurJoueur(ZeldaMonogameGame game)
        {
            _game = game;
        }

        /// <summary>
        /// Update la position du personnage et la caméra à chaque boucle de jeu
        /// </summary>
        /// <param name="gameTime">boucle de jeu</param>
        public void Update(GameTime gameTime)
        {
            var seconds = gameTime.GetElapsedSeconds();
            Vector2 direction = _game.GetterInput.GetDirection(); //récupère la direction dans laquelle le déplacer

            Vector2 newPos = _game.PersonnagePrincipal.Position + _game.PersonnagePrincipal.Speed * direction * seconds;


            MoveEntite(newPos); 
            _game.Map.MoveCamera(_game.PersonnagePrincipal.Position); //update la position de la caméra de la carte par rapport aux coordonées du personnage
        }

        /// <summary>
        /// Modifie la position du personnage si aucune collisions/aucun évènements de lancer
        /// </summary>
        /// <param name="newPos">nouvelle position du personnage</param>
        /// <returns></returns>
        public bool MoveEntite(Vector2 newPos)
        {
            if (!_game.Map.IsOnCollisionTile((ushort)newPos.X, (ushort)newPos.Y)
                && newPos.X > 0 && newPos.X < _game.Map.Width && newPos.Y > 0 && newPos.Y < _game.Map.Height)
            {
                _game.PersonnagePrincipal.Position = newPos;
                var evt = _game.Map.GetEventFromPos(newPos.X, newPos.Y);

                if (evt != null && (evt.Type == EventType.auto || evt.Type == EventType.interact && _game.GetterInput.IsInteractPressed()))
                    evt.Do();

                return true;
            }
            return false;
        }
    }
}
