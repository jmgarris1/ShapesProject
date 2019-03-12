using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShapes
{
    class Rectangle : Shape
    {
        public Rectangle(int top, int left, int width, int height, ConsoleColor color = ConsoleColor.White)
        {
            this.Top = top;
            this.Left = left;
            this.Width = width;
            this.Height = height;
            this.Color = color;
        }

        public Rectangle()
        {
            this.Top = 0;
            this.Left = 0;
            this.Width = 10;
            this.Height = 10;
            this.Color = ConsoleColor.White;
        }

        public override void Draw()
        {
            int newheight = (int)((float)(Height + Console.CursorSize) * (float)((float)(Console.LargestWindowHeight) / (float)(Console.LargestWindowWidth)));

            DrawAt("\u250C", Top, Left, Color);
            for (int x = 1; x < Width; x++)
                DrawAt("\u2500", Top, Left + x, Color);

            DrawAt("\u2510", Top, Left + Width, Color);

            for (int y = 1; y < newheight; y++)
            {
                DrawAt("\u2502", Top + y, Left, Color);
                DrawAt("\u2502", Top + y, Left + Width, Color);
            }

            DrawAt("\u2514", Top + newheight, Left, Color);

            for (int x = 1; x < Width; x++)
                DrawAt("\u2500", Top + newheight, Left + x, Color);

            DrawAt("\u2518", Top + newheight, Left + Width, Color);

        }
    }
}
