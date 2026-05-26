using GeometryLib.Core;

namespace GeometryLib.Features.Line;

public class Line : IShape
{
    public PointD pointA;
    public PointD pointB;
    public string ShapeType { get; } = "line";

    public Line(PointD pointA, PointD pointB)
    {
        this.pointA = pointA;
        this.pointB = pointB;
    }


    
        public string Draw() => $"line from {pointA} to {pointB}";
    

    public double X1 => pointA.X;
    public double Y1 => pointA.Y;
    public double X2 => pointB.X;
    public double Y2 => pointB.Y;
        
    public double A => Y2 - Y1;
    public double B => X1 - X2;
    public double C => X2 * Y1 - X1 * Y2;
        
    public double Length => Math.Sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1));
}