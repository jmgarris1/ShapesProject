using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            try
            {
                // Create a list (using the .NET List class) of shapes 
                //// and add two of each child class to the list.
                shapes.Add(new Rectangle(20, 20, 20, 20));
                shapes.Add(new Rectangle(10, 20, 10, 20, ConsoleColor.Blue));
                shapes.Add(new Triangle(10, 10, 20, 10, ConsoleColor.Yellow));
                shapes.Add(new Triangle());

                //  Go down the list and draw each item using the Draw method
                //foreach (var shape in shapes)
                //{
                //    shape.Draw();
                //}

                while (!Console.KeyAvailable)
                {
                    foreach (var shape in shapes)
                    {
                        shape.MoveHorizontal();
                        shape.MoveVertical();
                    }
                }
            }
            catch (ShapeException err)
            {
                Console.Clear();
                Console.WriteLine(err.Message);
                if (err.InnerException != null) Console.WriteLine(err.InnerException.Message);
                Console.ReadLine();
            }
            catch (Exception err)
            {
                Console.Clear();
                Console.WriteLine(err.Message);
                Console.ReadLine();
            }

        }
    }
}
