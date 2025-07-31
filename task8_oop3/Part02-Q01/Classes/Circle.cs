using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task8_oop3.Interfaces;

namespace task8_oop3.Classes
{
    internal class Circle : ICircle
    {
        public double Radius { get ; private set ; }
        public double Area => Math.PI * Radius * Radius;

        public Circle(double _radius)
        {
            Radius = _radius ;
        }

        public void DisplayShapeInfo()
        {
            Console.WriteLine("Shape: Circle");
            Console.WriteLine($"Radius: {Radius}");
            Console.WriteLine($"Area: {Area:F2}");
        }
    }
}
