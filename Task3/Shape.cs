using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public abstract class Shape
    {
        protected Shape(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public virtual string GetName()
        {
            return "Shape: " + Name;
        }

        public abstract double GetArea();

        public abstract double GetPerimeter();

    }

    public class Triangle : Shape
    {
        private double triangleBase;
        private double side2;
        private double side3;

        private double height;

        public Triangle(string name, double triangleBase, double side2, double side3, double height) : base(name)
        {
            this.triangleBase = triangleBase;
            this.side2 = side2;
            this.side3 = side3;

            this.height = height;
        }

        public override double GetArea()
        {
            double area = (triangleBase * height) / 2;
            return area;
        }

        public override double GetPerimeter()
        {
            double perimeter = triangleBase + side2 + side3;
            return perimeter;
        }
    }

    public class Circle : Shape
    {
        private double radius;

        public Circle(string name, double radius) : base(name)
        {
            this.radius = radius;
        }

        public override double GetArea()
        {
            double area = radius * radius * Math.PI;
            return area;
        }

        public override double GetPerimeter()
        {
            double perimeter = 2 * radius * Math.PI;
            return perimeter;
        }
    }

    public class Rectangle : Shape
    {
        protected double side1;
        protected double side2;

        public Rectangle(string name, double side1, double side2) : base(name)
        {
            this.side1 = side1;
            this.side2 = side2;
        }

        public override double GetArea()
        {
            double area = side1 * side2;
            return area;
        }

        public override double GetPerimeter()
        {
            double perimeter = 2 * (side1 + side2);
            return perimeter;
        }
    }

    public class Square : Rectangle
    {
        private double side;

        public Square(string name, double side) : base(name, side, side)
        {
            this.side = side;
        }

        public override double GetArea()
        {
            double area = side * side;
            return area;
        }

        public override double GetPerimeter()
        {
            double perimeter = 4 * side;
            return perimeter;
        }
    }
}