using StateDrivenUIDesign.View;
using System;

namespace StateDrivenUIDesign
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
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
