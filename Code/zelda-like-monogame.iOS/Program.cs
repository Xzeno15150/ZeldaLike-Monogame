using System;
using Foundation;
using UIKit;

namespace zelda-like-monogame.iOS
{
    [Register("AppDelegate")]
    class Program : UIApplicationDelegate
    {
        private static zelda-like-monogameGame game;

        internal static void RunGame()
        {
            game = new zelda-like-monogameGame();
            game.Run();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            UIApplication.Main(args, null, "AppDelegate");
        }

        public override void FinishedLaunching(UIApplication app)
        {
            RunGame();
        }
    }
}
