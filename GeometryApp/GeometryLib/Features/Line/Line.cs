using GeometryLib.Core;

namespace GeometryLib.Features.Line;

public class Line : IShape
{
    private PointD pointA;
    private PointD pointB;
    public string ShapeType { get; } = "Line";

    public Line(PointD pointA, PointD pointB)
    {
        this.pointA = pointA;
        this.pointB = pointB;
    }


    public string Draw()
    {
        return $"Line from {pointA} to {pointB}   (X1: {pointA.X}, Y1: {pointA.Y}; X2: {pointB.X}, Y2: {pointB.Y})";;
    }

    public double X1 => pointA.X;
    public double Y1 => pointA.Y;
    public double X2 => pointB.X;
    public double Y2 => pointB.Y;
        
    public double A => Y2 - Y1;
    public double B => X1 - X2;
    public double C => X2 * Y1 - X1 * Y2;
        
    public double Length => Math.Sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1));
}