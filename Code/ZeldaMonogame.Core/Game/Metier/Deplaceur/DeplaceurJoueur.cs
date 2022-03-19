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

        private Map.Map Map { get; set; } //Gestionnaire de la map
        private Joueur _joueur; //Joueur à déplacer

        private IGetterInput _getterInput; //Getter pour la direction

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="map"> gestionnaire de la map</param>
        /// <param name="joueur"> joueur à déplacer</param>
        /// <param name="getterInput">getter pour la direction</param>
        public DeplaceurJoueur(Map.Map map, Joueur joueur, IGetterInput getterInput)
        {
            Map = map;
            _joueur = joueur;
            _getterInput = getterInput;
        }

        /// <summary>
        /// Update la position du personnage et la caméra à chaque boucle de jeu
        /// </summary>
        /// <param name="gameTime">boucle de jeu</param>
        public void Update(GameTime gameTime)
        {
            var seconds = gameTime.GetElapsedSeconds();
            Vector2 direction = _getterInput.GetDirection(); //récupère la direction dans laquelle le déplacer

            Vector2 newPos = _joueur.Position + _joueur.Speed * direction * seconds;


            MoveEntite(newPos); 
            Map.MoveCamera(_joueur.Position); //update la position de la caméra de la carte par rapport aux coordonées du personnage
        }

        /// <summary>
        /// Modifie la position du personnage si aucune collisions/aucun évènements de lancer
        /// </summary>
        /// <param name="newPos">nouvelle position du personnage</param>
        /// <returns></returns>
        public bool MoveEntite(Vector2 newPos)
        {
            if (!Map.IsOnCollisionTile((ushort)newPos.X, (ushort)newPos.Y)
                && newPos.X > 0 && newPos.X < Map.Width && newPos.Y > 0 && newPos.Y < Map.Height)
            {
                _joueur.Position = newPos;
                var evt = Map.GetEventFromPos(newPos.X, newPos.Y);

                if (evt != null && (evt.Type == EventType.auto || evt.Type == EventType.interact && _getterInput.IsInteractPressed()))
                    evt.Do();

                return true;
            }
            return false;
        }
    }
}
