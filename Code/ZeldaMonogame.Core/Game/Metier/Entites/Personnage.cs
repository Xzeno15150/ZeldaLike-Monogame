using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaMonogame.Core.Game.Metier.Entites
{
    public abstract class Personnage : Entite
    {
        public Personnage(ZeldaMonogameGame game) : this(game, 0, 0)
        {
        }

        public Personnage(ZeldaMonogameGame game, float x, float y) : base(game, x, y)
        {

        }
    }
}
