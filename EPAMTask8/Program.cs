using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using Task3;

namespace EPAMTask8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shape = new List<Shape>();
            shape.Add(new Triangle("Triangle", 20, 10, 10, 15));
            shape.Add(new Rectangle("Rectangle", 30, 40));
            shape.Add(new Square("Square", 50));
            shape.Add(new Circle("Circle", 25));

            foreach (var item in shape)
            {
                Console.WriteLine($"{item.Name}: Area = {item.GetArea()}, Perimeter = {item.GetPerimeter()}");
            }
        }

    }
}
