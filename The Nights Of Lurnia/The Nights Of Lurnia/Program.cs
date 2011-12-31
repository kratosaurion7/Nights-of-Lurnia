using System;

namespace The_Nights_Of_Lurnia
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (LurniaGame game = new LurniaGame())
            {
                game.Run();
            }
        }
    }
#endif
}

