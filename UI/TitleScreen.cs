using System;
using System.Collections.Generic;
using System.Text;

namespace GoldenLotus.UI
{
    public class TitleScreen : GameScreen
    {
        private BorderedConsole titleCons = new BorderedConsole(80, 30, "Tales of the Golden Lotus"                                                 );
        public TitleScreen() : base("title") { }

        protected override void onInit()
        {
            titleCons.Position = new Microsoft.Xna.Framework.Point(10, 5);
            Children.Add(titleCons);
        }
    }
}
