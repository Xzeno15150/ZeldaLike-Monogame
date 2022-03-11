using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaMonogame.Core.Game.Metier.Input
{
    public class InputKeyboard : IGetterInput
    {
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
    }
}
