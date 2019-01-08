using System;

namespace MarioBros
{
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
            using (Game1 game = Game1.GetInstance())
            {
                game.Run();
            }
        }
    }
}
