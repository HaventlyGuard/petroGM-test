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
        
        public bool Equals(PointD other) 
            => Math.Abs(X - other.X) < 1e-9 && Math.Abs(Y - other.Y) < 1e-9;
            
        public override bool Equals(object? obj) 
            => obj is PointD other && Equals(other);
            
        public override int GetHashCode() 
            => HashCode.Combine(X, Y);
            
        public static bool operator ==(PointD left, PointD right) 
            => left.Equals(right);
            
        public static bool operator !=(PointD left, PointD right) 
            => !left.Equals(right);
      
    }
}