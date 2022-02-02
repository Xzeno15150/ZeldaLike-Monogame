using System;

namespace ZeldaMonogame.DesktopGL
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new ZeldaMonogameGame())
                game.Run();
        }
    }
}
