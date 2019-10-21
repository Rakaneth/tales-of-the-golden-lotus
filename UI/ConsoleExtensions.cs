﻿using System;
using System.Collections.Generic;
using System.Text;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;

namespace GoldenLotus.UI
{
    public static class ConsoleExtensions
    {
        public static string Decorate(string text, string fg, string bg)
        {
            return $"[c:r f:{fg}][c:r b:{bg}]{text}[c:undo][c:undo]";
        }
        public static void WriteCenter(this Console cons, int y, string text, string fg = "default", string bg = "default")
        {
            int x = (cons.Width - text.Length) / 2;
            cons.Cursor.Position = new Point(x, y);
            cons.Cursor.Print(Decorate(text, fg, bg));
        }

        public static void Border(this Console cons, string caption = null)
        {
            cons.DrawBox(
                new Rectangle(0, 0, cons.Width, cons.Height),
                new Cell(cons.DefaultForeground, cons.DefaultBackground),
                connectedLineStyle: CellSurface.ConnectedLineThick);

            if (caption != null)
            {
                int cx = (cons.Width - caption.Length) / 2;
                cons.Print(cx, 0, caption);
            }
        }
    }
}
