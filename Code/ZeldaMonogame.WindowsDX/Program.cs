using System;

namespace ZeldaMonogame.WindowsDX
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
