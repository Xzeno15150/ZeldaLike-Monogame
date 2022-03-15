using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaMonogame.Core.Game.Metier.Events
{
    public abstract class Event
    {
        protected ZeldaMonogameGame Game { get; set; }
        protected Vector2 TiledPostionOnMap { get;  set; }


        public Event(ZeldaMonogameGame game, int x, int y)
        {
            Game = game;
            TiledPostionOnMap = new Vector2(x, y);
        }

        public abstract void Do();
    }
}
