using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaMonogame.Core.Game.Metier.Entites
{
    public class Entite : DrawableGameComponent, IMovable
    {
        public Vector2 Position { get; set; }

        public Entite(ZeldaMonogameGame game) : base(game)
        {
            
        }
        
    }
}
