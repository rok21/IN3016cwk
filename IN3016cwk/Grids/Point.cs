using System;

namespace IN3016cwk.Grids
{
    public abstract class Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsAdjecant(Point other)
        {
            return Math.Abs(other.Y - Y) < 2 && Math.Abs(other.X - X) < 2 && ! Equals(other);
        }

        public bool Equals(Point other)
        {
            return other.Y == Y && other.X == X;
        }
    }
}
