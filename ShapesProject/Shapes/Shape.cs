using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyShapes
{
    public abstract class Shape
    {
        private int horizontalmove = 1; // use to move 
        private int verticalmove = 1; // use to move

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }


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

        /// <summary>
        /// Return the perimeter of the shape
        /// </summary>
        public abstract int Perimeter
        {
            get;
        }

        /// <summary>
        /// Return the area of the shape
        /// </summary>
        public abstract int Area
        {
            get;
        }

        /// <summary>
        /// Method to draw the given shape
        /// </summary>
        public abstract void Draw();

        /// <summary>
        ///  Method to move the shape horizontally on the screen
        ///  Use a variable to represent the x direction (1 moves to the right, -1 move to the left)
        /// </summary>
        public void MoveHorizontal()
        {
            var temp = this.Color; // save current color
            this.Color = Console.BackgroundColor; // assign background color to erase previous draw
            this.Draw(); // draw using black (screen background)
            this.Color = temp; // change back to our shapes color

            // check to see if we have hit the edge of the screen
            if (this.left + this.width + horizontalmove + 1 > Console.WindowWidth)
                horizontalmove = -1;

            if (this.left + horizontalmove == 0)
                horizontalmove = 1;

            this.Left += horizontalmove; // move left or right
            this.Draw(); // now draw
            //Thread.Sleep(speed);
        }

        /// <summary>
        ///  Method to move the shape vertically on the screen
        ///  Use a variable to represent the y direction (1 moves to the down, -1 move to the up)
        /// </summary>
        public void MoveVertical()
        {
            var temp = this.Color; // save current color
            this.Color = Console.BackgroundColor; // assign background color to erase previous draw
            this.Draw(); // draw using black (screen background)
            this.Color = temp; // change back to our shapes color

            // check to see if we have hit the edge of the screen
            if (this.top + verticalmove + this.height + 1 > Console.WindowHeight)
                verticalmove = -1;

            if (this.top + verticalmove == 0)
                verticalmove = 1;

            this.Top += verticalmove; // move up or down
            this.Draw(); // now draw
            //Thread.Sleep(speed);
        }

        /// <summary>
        /// Method to draw the string at the given x and y location
        /// in the given color.
        /// </summary>
        /// <param name="s">Out string (normally a character)</param>
        /// <param name="x">Column location on the console</param>
        /// <param name="y">Row location on the console</param>
        /// <param name="color">ConsoleColor enumerator for the given color to draw string.</param>
        protected void DrawAt(string s, int x, int y, ConsoleColor color)
        {
            try
            {
                // Can use either SetCursorPosition or CursorLeft and CursorRight
                // Console.SetCursorPosition(y, x);
                Console.CursorLeft = y;
                Console.CursorTop = x;
                Console.ForegroundColor = color;
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Type type = this.GetType();
                throw new ShapeException(type.ToString() + ".DrawAt Error: Coordinate Out of Range.", e);
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
