using System;

namespace zelda-like-monogame.DesktopGL
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new zelda-like-monogameGame())
                game.Run();
        }
    }
}
