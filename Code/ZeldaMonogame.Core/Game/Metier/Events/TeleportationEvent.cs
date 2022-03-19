using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaMonogame.Core.Game.Metier.Events
{
    /// <summary>
    /// Event de téléportation
    /// </summary>
    public class TeleportationEvent : Event
    {
        public string _nameNewMap; //nom de la carte vers laquelle téléporter

        public Vector2 TeleportOnPosition { get; set; } //position de spawn de la map



        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="game">manager du jeu</param>
        /// <param name="xOldMap">coordonnées x de l'ancienne tuile</param>
        /// <param name="yOldMap">coordonnées y de l'ancienne tuile</param>
        /// <param name="nameNewMap">nom de la nouvelle map</param>
        /// <param name="xNewMap">nouvelle position du personnage en x</param>
        /// <param name="yNewMap">nouvelle position du personnage en y</param>
        /// <param name="type">type de l'event</param>
        public TeleportationEvent(ZeldaMonogameGame game, int xOldMap, int yOldMap, string nameNewMap, int xNewMap, int yNewMap, EventType type) : base(game, xOldMap, yOldMap, type)
        {
            _nameNewMap = nameNewMap;
            TeleportOnPosition = new Vector2(xNewMap, yNewMap);
        }

        /// <summary>
        /// Change la map
        /// </summary>
        public override void Do()
        {
            Game.ChangeMap(_nameNewMap, TeleportOnPosition);
        }
    }
}
