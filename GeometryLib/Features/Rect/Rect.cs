using GeometryLib.Core;

namespace GeometryLib.Features.Rect
{
    public class Rect : IShape
    {
        public PointD TopLeft { get; }
        public PointD BottomRight { get; }
        public string ShapeType => "rect";
        
        public Rect(double x1, double y1, double x2, double y2) 
            : this(new PointD(x1, y1), new PointD(x2, y2))
        {
        }
        
        public Rect(PointD topLeft, PointD bottomRight)
        {
            TopLeft = new PointD(
                Math.Min(topLeft.X, bottomRight.X),
                Math.Min(topLeft.Y, bottomRight.Y));
                
            BottomRight = new PointD(
                Math.Max(topLeft.X, bottomRight.X),
                Math.Max(topLeft.Y, bottomRight.Y));
        }
        
        public string Draw() => $"rect at {TopLeft}, {BottomRight}";
        
        public double Left => TopLeft.X;
        public double Top => TopLeft.Y;
        public double Right => BottomRight.X;
        public double Bottom => BottomRight.Y;
        public double Width => Right - Left;
        public double Height => Bottom - Top;
        
        public (PointD Start, PointD End)[] GetEdges()
        {
            return new[]
            {
                (new PointD(Left, Top), new PointD(Right, Top)),       
                (new PointD(Right, Top), new PointD(Right, Bottom)),   
                (new PointD(Right, Bottom), new PointD(Left, Bottom)),
                (new PointD(Left, Bottom), new PointD(Left, Top))      
            };
        }
    }
}