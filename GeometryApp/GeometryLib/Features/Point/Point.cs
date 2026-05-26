using GeometryLib.Core;

namespace GeometryLib.Features.Point;

public class Point : IShape
{
    private PointD Position { get; set; }

    public Point(PointD pos)
    {
        Position = pos;
    }
    
    public string Draw()
    {
        return $"point at position: X: {Position.X}, Y: {Position.Y}";
    }

    public IntersectionResult Intersect(IShape other)
    {
        return IntersectionResult.CannotIntersect(this, other);
    }
}