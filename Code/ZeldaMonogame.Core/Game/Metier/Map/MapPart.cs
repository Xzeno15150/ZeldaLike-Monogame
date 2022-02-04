using System;
using System.Collections.Generic;
using System.Text;
using TiledSharp;

namespace ZeldaMonogame.Core.Game.Metier.Map
{
    class MapPart
    {

        public static readonly double longueur = 16;
        public static readonly double hauteur = 16;
        public TmxMap Map { get; private set; }

        public MapPart(string cheminMap)
        {
            Map = new TmxMap(cheminMap);
        }

    }
}
