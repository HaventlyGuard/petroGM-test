namespace GeometryLib.Core
{
    public class IntersectionResult
    {
        public bool HasIntersection { get; }
        public IReadOnlyList<PointD> Points { get; }
        public string Message { get; }
        
        private IntersectionResult(bool hasIntersection, IReadOnlyList<PointD> points, string message)
        {
            HasIntersection = hasIntersection;
            Points = points;
            Message = message;
        }
        
        public static IntersectionResult Intersects(params PointD[] points) 
            => new(true, points, $"Intersection at {string.Join(" and ", points)}");
            
        public static IntersectionResult NoIntersection() 
            => new(false, Array.Empty<PointD>(), "No intersections");
            
        public static IntersectionResult CannotIntersect(IShape shape1, IShape shape2) 
            => new(false, Array.Empty<PointD>(), $"The {shape1.GetType().Name.ToLower()} cannot intersect the {shape2.GetType().Name.ToLower()}");
    }
}