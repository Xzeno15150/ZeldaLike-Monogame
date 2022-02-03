using System;
using System.Collections.Generic;
using System.Text;
using ZeldaMonogame.Core.Game.Metier.Entites;

namespace ZeldaMonogame.Core.Game.Metier.Fabriques.Fabriques_Entites
{
    public interface IFabriqueEntite
    {

        Entite fabriquer(Microsoft.Xna.Framework.Game game);
    }
}
