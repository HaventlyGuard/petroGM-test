using System.Diagnostics.CodeAnalysis;

namespace GeometryLib.Core
{
    public readonly struct PointD
    {
        public double X { get; }
        public double Y { get; }
        
        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        public override string ToString() => $"({X}, {Y})";
        public bool Equals(PointD other) => X.Equals(other.X) && Y.Equals(other.Y);
      
    }
}