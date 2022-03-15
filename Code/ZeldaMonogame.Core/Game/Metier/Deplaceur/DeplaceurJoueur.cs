using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaMonogame.Core.Game.Metier.Entites;
using ZeldaMonogame.Core.Game.Metier.Input;

namespace ZeldaMonogame.Core.Game.Metier.Deplaceur
{
    public class DeplaceurJoueur : IDeplaceurEntite
    {

        private Map.Map Map { get; set; }
        private Joueur _joueur;

        private IGetterInput _getterInput;

        public DeplaceurJoueur(Map.Map map, Joueur joueur, IGetterInput getterInput)
        {
            Map = map;
            _joueur = joueur;
            _getterInput = getterInput;
        }

        public void Update(GameTime gameTime)
        {
            var seconds = gameTime.GetElapsedSeconds();
            Vector2 direction = _getterInput.GetDirection();

            Vector2 newPos = _joueur.Position + _joueur.Speed * direction * seconds;


            MoveEntite(newPos);
            Map.MoveCamera(_joueur.Position);
        }

        public bool MoveEntite(Vector2 newPos)
        {
            if (!Map.IsOnCollisionTile((ushort)newPos.X, (ushort)newPos.Y)
                && newPos.X > 0 && newPos.X < Map.Width && newPos.Y > 0 && newPos.Y < Map.Height)
            {
                _joueur.Position = newPos;
                return true;
            }
            return false;
        }
    }
}
