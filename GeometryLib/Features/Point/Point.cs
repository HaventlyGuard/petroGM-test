using GeometryLib.Core;
using System.Globalization;

namespace GeometryLib.Features.Point;

public class Point : IShape
{
    private PointD Position { get; set; }
    public string ShapeType { get; } = "point";

    public Point(PointD pos)
    {
        Position = pos;
    }
    
    public string Draw() => string.Format(CultureInfo.InvariantCulture, "point at ({0:F2}, {1:F2})", X, Y);
    
    public double X => Position.X;
    public double Y => Position.Y;

   
}