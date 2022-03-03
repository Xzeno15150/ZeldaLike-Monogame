using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;
using ZeldaMonogame.Core.Game.Metier.Entites;

namespace ZeldaMonogame.Core.Game.Deplacement
{
    public abstract class Deplaceur
    {

        public Vector2 GetMovementDirection(ISet<Direction> directions)
        {
            var movementDirection = Vector2.Zero;
            if (directions.Contains(Direction.Bas))
            {
                movementDirection += Vector2.UnitY;
            }
            if (directions.Contains(Direction.Haut))
            {
                movementDirection -= Vector2.UnitY;
            }
            if (directions.Contains(Direction.Gauche))
            {
                movementDirection -= Vector2.UnitX;
            }
            if (directions.Contains(Direction.Droite))
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

        public bool Deplacer(GameTime gameTime, ISet<Direction> directions)
        {
            var speed = Speed;
            var seconds = gameTime.GetElapsedSeconds();
            var movementDirection = GetMovementDirection(directions);

            return Move(movementDirection * speed * seconds);
        }

        protected abstract bool Move(Vector2 movement);

        protected abstract int Speed { get; }
    }

    public enum Direction
    {
        Haut,
        Bas,
        Gauche,
        Droite,
    }
}