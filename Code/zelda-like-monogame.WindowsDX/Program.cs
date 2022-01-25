using System;

namespace zelda-like-monogame.WindowsDX
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
