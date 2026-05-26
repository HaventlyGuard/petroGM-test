using GeometryLib.Core;

namespace GeometryLib.Features.Circle
{
    public class Circle : IShape
    {
        public PointD Center { get; }
        public double Radius { get; }
        public string ShapeType => "circle";
        
        public Circle(double x, double y, double radius) 
            : this(new PointD(x, y), radius)
        {
        }
        
        public Circle(PointD center, double radius)
        {
            Center = center;
            Radius = radius;
        }
        
        public string Draw() => $"circle at {Center}, radius = {Radius}";
        
        public double X => Center.X;
        public double Y => Center.Y;
    }
}