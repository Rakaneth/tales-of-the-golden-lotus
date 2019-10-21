using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;

namespace GoldenLotus.UI
{
    public abstract class GameScreen : ContainerConsole
    {
        public string Name { get; }
        protected GameScreen(string name)
        {
            Name = name;
            IsVisible = false;
            IsFocused = false;
            onInit();
        }

        protected abstract void onInit();
        public virtual void Enter()
        {
            System.Console.WriteLine($"Entered {Name} screen.");
        }

        public virtual void Exit()
        {
            System.Console.WriteLine($"Exited {Name} screen.");
        }

    }
}
