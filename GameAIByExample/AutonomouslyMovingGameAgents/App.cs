using System;
using AutonomouslyMovingGameAgents.View;

namespace AutonomouslyMovingGameAgents
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class App
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new GameView())
                game.Run();
        }
    }
#endif
}
