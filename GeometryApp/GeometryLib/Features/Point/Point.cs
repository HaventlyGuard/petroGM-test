using GeometryLib.Core;

namespace GeometryLib.Features.Point;

public class Point : IShape
{
    private PointD Position { get; set; }
    public string ShapeType { get; } = "Point";

    public Point(PointD pos)
    {
        Position = pos;
    }
    
    public string Draw()
    {
        return $"point at position: X: {Position.X}, Y: {Position.Y}";
    }
    
    public double X => Position.X;
    public double Y => Position.Y;

   
}