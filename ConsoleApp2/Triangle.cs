using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Triangle : Shape
    {
        public Triangle(int top, int left, int width, int height, ConsoleColor color = ConsoleColor.White)
        {
            this.Top = top;
            this.Left = left;
            this.Width = width;
            this.Height = height;
            this.Color = color;
        }

        public Triangle()
        {
            this.Top = 0;
            this.Left = 0;
            this.Width = 10;
            this.Height = 10;
            this.Color = ConsoleColor.White;
        }

        public override void Draw()
        {
            DrawAt("*", Top, Left, Color);
   
            for (int y = 1; y < Height; y++)
            {
                DrawAt("*", Top + y, Left, Color);
                DrawAt("*", Top + y, Left + y, Color);
            }

            DrawAt("*", Top + Height, Left, Color);

            for (int x = 1; x < Width; x++)
                DrawAt("*", Top + Height, Left + x, Color);

            DrawAt("*", Top + Height, Left + Width, Color);
        }
    }
}
