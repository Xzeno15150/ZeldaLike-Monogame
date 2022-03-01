using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;
using ZeldaMonogame.Core.Game.Metier.Entites;

namespace ZeldaMonogame.Core.Game.Deplacement
{
    public class DeplaceurEntite : IDeplaceur
    {
        private static readonly int VITESSE = 200;

        private Entite _entite;
        private int _mapHeight;
        private int _mapWidth;

        public DeplaceurEntite(Entite entite, int height, int width)
        {
            _entite = entite;
            _mapHeight = height;
            _mapWidth = width;
        }

        public DeplaceurEntite(Entite entite)
        {
            _entite = entite;
        }

        public void SetMapTaille(int width, int height)
        {
            _mapWidth = width;
            _mapHeight = height;
        }

        public void Deplacer(GameTime gameTime)
        {
            var seconds = gameTime.GetElapsedSeconds();
            var movementDirection = GetMovementDirection();

            _entite.Position += VITESSE * movementDirection * seconds;
        }
        private Vector2 GetMovementDirection()
        {
            var movementDirection = Vector2.Zero;
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.S))
            {
                movementDirection += Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.Z))
            {
                movementDirection -= Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.Q))
            {
                movementDirection -= Vector2.UnitX;
            }
            if (state.IsKeyDown(Keys.D))
            {
                movementDirection += Vector2.UnitX;
            }

            // Can't normalize the zero vector so test for it before normalizing
            if (movementDirection != Vector2.Zero)
            {
                movementDirection.Normalize();
            }

            return movementDirection;
        }
    }
}
