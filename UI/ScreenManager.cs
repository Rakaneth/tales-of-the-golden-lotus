using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;

namespace GoldenLotus.UI
{
    public sealed class ScreenManager
    {
        private static ScreenManager instance;
        private static readonly object padlock = new object();
        private Dictionary<string, GameScreen> screens = new Dictionary<string, GameScreen>();
        public GameScreen CurScreen => Global.CurrentScreen as GameScreen;
        public static ScreenManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null) instance = new ScreenManager();
                    return instance;
                }
            }
        }

        private ScreenManager() { }

        public void SetScreen(string screenName)
        {
            if (!screens.ContainsKey(screenName))
                throw new ArgumentException($"No screen named {screenName} registered.");
            
            if (CurScreen != null)
            {
                CurScreen.Exit();
                CurScreen.IsVisible = false;
                CurScreen.IsFocused = false;
            }

            GameScreen nextScreen = screens[screenName];
            nextScreen.IsVisible = true;
            nextScreen.IsFocused = true;
            Global.CurrentScreen = nextScreen;
            nextScreen.Enter();
        }

        public void Register(params GameScreen[] screenList)
        {
            foreach (GameScreen scr in screenList)
                screens[scr.Name] = scr;
        }

    }
}
