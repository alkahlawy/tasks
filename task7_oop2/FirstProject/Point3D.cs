
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task7_oop2
{
    internal class Point3D:IComparable<Point3D>, ICloneable
    {
        internal int X { get; set; }
        internal int Y { get; set; }
        internal int Z { get; set; }

        public Point3D()
        {
            // Do Nothing
        }
        public Point3D(int x, int y, int z)
        {
            X = x; Y = y; Z = z;
        }

        public Point3D(int x, int y) : this(x, y, 10)
        {
        }

        public Point3D(int x) : this(x, 10, 10)
        {
        }

        public override string ToString()
        {
            return $"Point Coordinates: ({X}, {Y}, {Z})";
        }

        public static bool operator ==(Point3D p1, Point3D p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            if (p1 is null || p2 is null) return false;
            return p1.X == p2.X && p1.Y == p2.Y && p1.Z == p2.Z;
        }

        public static bool operator !=(Point3D p1, Point3D p2) => !(p1 == p2);

        public int CompareTo(Point3D other)
        {
            if (this.X != other.X)
                return this.X.CompareTo(other.X);
            else
                return this.Y.CompareTo(other.Y);
        }

        // ICloneable implementation
        public object Clone()
        {
            return new Point3D(this.X, this.Y, this.Z);
        }

        public override bool Equals(object obj)
        {
            return obj is Point3D other && this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
    }
}
