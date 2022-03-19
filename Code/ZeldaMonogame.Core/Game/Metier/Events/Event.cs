using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaMonogame.Core.Game.Metier.Events
{
    /// <summary>
    /// Enum des types d'event disponibles
    /// </summary>
    public enum EventType
    {
        auto,
        interact
    }

    /// <summary>
    /// Représente un event
    /// </summary>
    public abstract class Event 
    {
        [JsonIgnore]
        public ZeldaMonogameGame Game { get; set; } //manager du jeu
        public Vector2 TiledPostionOnMap { get;  set; } //position de la tile associée à cet event

        public EventType Type { get; set; } //son type

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="game">manager du jeu</param>
        /// <param name="x">coordonnées x de la tile</param>
        /// <param name="y">coordonnées y de la tile</param>
        /// <param name="type">type de l'event</param>
        public Event(ZeldaMonogameGame game, int x, int y, EventType type)
        {
            Game = game;
            TiledPostionOnMap = new Vector2(x, y);
            Type = type;
        }

        /// <summary>
        /// Action de l'event
        /// </summary>
        public abstract void Do();
    }
}
