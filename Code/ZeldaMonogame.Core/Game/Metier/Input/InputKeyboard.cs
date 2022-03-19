using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaMonogame.Core.Game.Metier.Input
{
    /// <summary>
    /// Classe qui gère les entrées du clavier
    /// </summary>
    public class InputKeyboard : IGetterInput
    {
        /// <summary>
        /// Retourne un vecteur correspondant à la direction voulue
        /// </summary>
        /// <returns>Vector2</returns>
        public Vector2 GetDirection()
        {
            var state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Z))
                return new Vector2(0, -1);

            if (state.IsKeyDown(Keys.S))
                return new Vector2(0, 1);

            if (state.IsKeyDown(Keys.Q))
                return new Vector2(-1, 0);

            if (state.IsKeyDown(Keys.D))
                return new Vector2(1, 0);

            return Vector2.Zero;
        }

        /// <summary>
        /// Renvoie true si la touche espace est apputée lors d'une intéraction déclenchée
        /// </summary>
        /// <returns>bool</returns>
        public bool IsInteractPressed()
        {
            var state = Keyboard.GetState();

            return state.IsKeyDown(Keys.Space);
        }
    }
}
