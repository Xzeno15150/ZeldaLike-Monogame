using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaMonogame.Core.Game.Metier.Events
{
    public class TeleportationEvent : Event
    {
        public string _nameNewMap;

        public Vector2 TeleportOnPosition { get; set; }

        

        public TeleportationEvent(ZeldaMonogameGame game, int xOldMap, int yOldMap, string nameNewMap, int xNewMap, int yNewMap, EventType type) : base(game, xOldMap, yOldMap, type)
        {
            _nameNewMap = nameNewMap;
            TeleportOnPosition = new Vector2(xNewMap, yNewMap);
        }

        public override void Do()
        {
            Game.ChangeMap(_nameNewMap, TeleportOnPosition);
        }
    }
}
