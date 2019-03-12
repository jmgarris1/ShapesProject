using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShapes
{
    class Rectangle2 : Shape
    {
        public Rectangle2(int top, int left, int width, int height, ConsoleColor color = ConsoleColor.White)
        {
            this.Top = top;
            this.Left = left;
            this.Width = width;
            this.Height = height;
            this.Color = color;
        }

        public Rectangle2()
        {
            this.Top = 0;
            this.Left = 0;
            this.Width = 10;
            this.Height = 10;
            this.Color = ConsoleColor.White;
        }

        public override void Draw()
        {
            try
            {
                Console.ForegroundColor = Color;

                Console.SetCursorPosition(Left, Top);
                Console.Write("\u250C");

                for (int x = 1; x < Width; x++)
                {
                    Console.SetCursorPosition(Left + x, Top);
                    Console.Write("\u2500");
                }


                Console.SetCursorPosition(Left + Width, Top);
                Console.Write("\u2510");

                for (int y = 1; y < Height; y++)
                {
                    Console.SetCursorPosition(Left, Top + y);
                    Console.Write("\u2502");
                    Console.SetCursorPosition(Left + Width, Top + y);
                    Console.Write("\u2502");
                }

                Console.SetCursorPosition(Left, Top + Height);
                Console.Write("\u2514");

                for (int x = 1; x < Width; x++)
                {
                    Console.SetCursorPosition(Left + x, Top + Height);
                    Console.Write("\u2500");
                }
                Console.SetCursorPosition(Left + Width, Top + Height);
                Console.Write("\u2518");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }

        }
    }
}
