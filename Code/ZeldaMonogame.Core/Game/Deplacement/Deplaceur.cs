using System;
using System.Collections.Generic;
using System.Text;
using ZeldaMonogame.Core.Game.Metier.Entites;

namespace ZeldaMonogame.Core.Game.Deplacement
{
    public abstract class Deplaceur
    {
        public abstract void DeplacerHaut(Entite entite);
        public abstract void DeplacerBas(Entite entite);
        public abstract void DeplacerGauche(Entite entite);
        public abstract void DeplacerDroite(Entite entite);

    }
}
