using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task8_oop3.Interfaces;

namespace task8_oop3.Classes
{
    internal class Rectangle : IRectangle
    {
        public double Length { get; private set; }
        public double Width { get; private set; }

        public Rectangle(double _length, double _width)
        {
            Length = _length;
            Width = _width;
        }

        public double Area => Length * Width;

        public void DisplayShapeInfo()
        {
            Console.WriteLine("Shape: Rectangle");
            Console.WriteLine($"Length: {Length}, Width: {Width}");
            Console.WriteLine($"Area: {Area:F2}");
        }
    }
}
