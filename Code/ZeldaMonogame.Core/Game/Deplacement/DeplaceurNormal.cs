using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;
using ZeldaMonogame.Core.Game.Metier.Entites;

namespace ZeldaMonogame.Core.Game.Deplacement
{
    public class DeplaceurNormal : IDeplaceur
    {
        private int _vitesse;




        public void DeplacerBas(IMovable movable)
        {
        }

        public void DeplacerDroite(IMovable movable)
        {
            throw new NotImplementedException();
        }

        public void DeplacerGauche(IMovable movable)
        {
            throw new NotImplementedException();
        }

        public void DeplacerHaut(IMovable movable)
        {
            throw new NotImplementedException();
        }
    }
}
