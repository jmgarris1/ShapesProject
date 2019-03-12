using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Rectangle rect1 = new Rectangle();
                Rectangle2 rect2 = new Rectangle2(20, 20, 20, 20);
                Triangle tri3 = new Triangle(15, 15, 50, 50, ConsoleColor.Yellow);

                Triangle tri = new Triangle();
                tri.Draw();

                rect1.Color = ConsoleColor.Red;
                rect1.Draw();
                rect2.Draw();
                tri3.Draw();
                Console.ReadLine();
            }
            catch (ShapeException err)
            {
                Console.Clear();
                Console.WriteLine(err.Message);
                Console.ReadLine();
            }
            catch(Exception err)
            {
                Console.Clear();
                Console.WriteLine(err.Message);
                Console.ReadLine();
            }
            
        }
    }
}
