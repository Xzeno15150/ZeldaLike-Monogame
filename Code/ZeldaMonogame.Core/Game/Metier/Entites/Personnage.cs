using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaMonogame.Core.Game.Metier.Entites
{
    /// <summary>
    /// Représente un personnage
    /// </summary>
    public abstract class Personnage : Entite
    {
        /// <summary>
        /// Constructeur sans coordonées
        /// </summary>
        /// <param name="game">manager du jeu</param>
        public Personnage(ZeldaMonogameGame game) : this(game, 0, 0)
        {
        }


        /// <summary>
        /// Constructeur avec coordonées
        /// </summary>
        /// <param name="game">manager du jeu</param>
        /// <param name="x">coordonnées en x</param>
        /// <param name="y">coordonnées en y</param>
        public Personnage(ZeldaMonogameGame game, float x, float y) : base(game, x, y)
        {

        }
    }
}
