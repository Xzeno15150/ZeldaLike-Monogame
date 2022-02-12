using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;
using ZeldaMonogame.Core.Game.Metier.Entites;

namespace ZeldaMonogame.Core.Game.Deplacement
{
    public interface IDeplaceur
    {
        void DeplacerHaut(IMovable movable);
        void DeplacerBas(IMovable movable);
        void DeplacerGauche(IMovable movable);
        void DeplacerDroite(IMovable movable);

    }
}
