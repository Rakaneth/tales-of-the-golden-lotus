using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using Console = SadConsole.Console;

namespace GoldenLotus.UI
{
    public class BorderedConsole : Console
    {
        public string Caption { get; set; }
        public BorderedConsole(int width, int height, string caption = null) : base(width, height) 
        {
            Caption = caption;
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            this.Border(Caption);
            base.Draw(timeElapsed);
        }
    }
}
