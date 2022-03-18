using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaMonogame.Core.Game.Metier.Events
{
    public enum EventType
    {
        auto,
        interact
    }

    public abstract class Event 
    {
        [JsonIgnore]
        public ZeldaMonogameGame Game { get; set; }
        public Vector2 TiledPostionOnMap { get;  set; }

        public EventType Type { get; set; }


        public Event(ZeldaMonogameGame game, int x, int y, EventType type)
        {
            Game = game;
            TiledPostionOnMap = new Vector2(x, y);
            Type = type;
        }

        public abstract void Do();
    }
}
