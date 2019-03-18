using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShapes
{
    class Triangle : Shape
    {
        public override int Perimeter => throw new NotImplementedException();

        public override int Area => throw new NotImplementedException();

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
            // Draw the two sides of the triangle
            for (int y = 0; y < Height; y++)
            {
                DrawAt("*", Top + y, Left, Color);
                DrawAt("*", Top + y, Left + (int)((Width / Height) * y), Color);
            }

            // Draw the base of the triangle
            for (int x = 0; x < Width; x++)
                DrawAt("*", Top + Height, Left + x, Color);


            DrawAt("*", Top + Height, Left + Width, Color);
        }
    }
}
