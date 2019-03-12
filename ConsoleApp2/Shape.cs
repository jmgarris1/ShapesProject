using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public abstract class Shape
    {
        private int top;

        public int Top
        {
            get { return top; }
            set
            {
                if (value < 0 || value > Console.LargestWindowHeight)
                    throw new ShapeException("Top", value, "Top should be in range of 0 to " + Console.LargestWindowHeight);
                top = value;
            }
        }

        private int left;

        public int Left
        {
            get { return left; }
            set
            {
                if (value < 0 || value > Console.LargestWindowWidth)
                    throw new ShapeException("Left", value, "Left should be in range of 0 to " + Console.LargestWindowWidth);
                left = value;
            }
        }

        private ConsoleColor color;

        public ConsoleColor Color
        {
            get { return color; }
            set
            {
                if (value < ConsoleColor.Black || value > ConsoleColor.White)
                    throw new ShapeException("Color", value, "Not a console color");
                color = value;
            }
        }

        private int height;

        public int Height
        {
            get { return height; }
            set
            {
                if (value < 0 || value > Console.LargestWindowHeight)
                    throw new ShapeException("Height", value, "Height should be in range of 0 to " + Console.LargestWindowHeight);
                height = value;
            }
        }

        private int width;

        public int Width
        {
            get { return width; }
            set
            {
                if (value < 0 || value > Console.LargestWindowWidth)
                    throw new ShapeException("Width", value, "Width should be in range of 0 to " + Console.LargestWindowWidth);
                width = value;
            }
        }

        private int perimeter;

        public int Perimeter
        {
            get { return perimeter; }
            set { perimeter = value; }
        }



        public int Area
        {
            get
            {
                return 1;
            }
        }
        
        public abstract void Draw();

        protected void DrawAt(string s, int x, int y, ConsoleColor color)
        {
            try
            {
                Console.SetCursorPosition(y, x);
                Console.ForegroundColor = color;
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ShapeException("DarwAt Error: Coordinate Out of Range.", e);
            }
        }
    }

    [Serializable]
    public class ShapeException : Exception
    {
        public ShapeException() { }
        public ShapeException(string message) : base(message) { }
        public ShapeException(string message, Exception inner) : base(message, inner) { }

        public ShapeException(string title, object value, string message) : base("ShapeException\n" + title + ": " + message + "\nBad value is " + value) { }
        protected ShapeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
