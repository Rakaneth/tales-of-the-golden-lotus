using System;
using SadConsole;
using Microsoft.Xna.Framework;
using Console = SadConsole.Console;
using GoldenLotus.UI;

namespace GoldenLotus
{
    public static class Program
    {
        public const int SCREEN_WIDTH = 100;
        public const int SCREEN_HEIGHT = 40;
        static void Main(string[] args)
        {
            SadConsole.Game.Create(SCREEN_WIDTH, SCREEN_HEIGHT);
            SadConsole.Game.OnInitialize = Init;
            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();
        }

        private static void Init()
        {
            ScreenManager.Instance.Register(new TitleScreen());
            ScreenManager.Instance.SetScreen("title");
        }
    }
}
