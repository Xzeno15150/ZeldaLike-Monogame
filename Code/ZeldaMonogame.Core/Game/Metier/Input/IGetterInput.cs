using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaMonogame.Core.Game.Metier.Input
{
    /// <summary>
    /// Interface pour récupérer des entrées
    /// </summary>
    public interface IGetterInput
    {
        /// <summary>
        /// Retourne un vecteur correspondant à la direction pointée
        /// </summary>
        /// <returns>Vector2</returns>
        Vector2 GetDirection();
    }
}
