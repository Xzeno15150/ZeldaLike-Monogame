using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;
using ZeldaMonogame.Core.Game.Metier.Entites;

namespace ZeldaMonogame.Core.Game.Deplacement
{
    public class DeplaceurEntite : Deplaceur
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

        protected override bool Move(Vector2 movement)
        {
            _entite.Position += movement;
            return true;
            // TODO Déplacer seulement s'il n'y a pas de collisions
        }

        protected override int Speed => 200;

        internal bool IsOutOfCameraOffsets(IDictionary<string, int> offsets)
        {
            var postion = _entite.Position;

            return postion.X < offsets["miniX"]
                || postion.X > offsets["maxiX"];
        }
    }
}
