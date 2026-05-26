namespace GeometryLib.Core
{
    public class IntersectionResult
    {
        public bool HasIntersection { get; }
        public IReadOnlyList<PointD> Points { get; }
        public string ShapeType1 { get; }
        public string ShapeType2 { get; }
        
        private IntersectionResult(
            bool hasIntersection, 
            string shapeType1, 
            string shapeType2, 
            IReadOnlyList<PointD> points)
        {
            HasIntersection = hasIntersection;
            ShapeType1 = shapeType1;
            ShapeType2 = shapeType2;
            Points = points ?? Array.Empty<PointD>();
        }
        

        public static IntersectionResult Intersects(
            string shapeType1, 
            string shapeType2, 
            params PointD[] points)
        {
            return new IntersectionResult(true, shapeType1, shapeType2, points);
        }
        

        public static IntersectionResult Intersects(
            string shapeType1, 
            string shapeType2, 
            IReadOnlyList<PointD> points)
        {
            return new IntersectionResult(true, shapeType1, shapeType2, points);
        }
        

        public static IntersectionResult NoIntersection(
            string shapeType1, 
            string shapeType2)
        {
            return new IntersectionResult(false, shapeType1, shapeType2, Array.Empty<PointD>());
        }
        

        public static IntersectionResult CannotIntersect(
            string shapeType1, 
            string shapeType2)
        {
            return new IntersectionResult(false, shapeType1, shapeType2, Array.Empty<PointD>());
        }
        

        public string ToMessage()
        {
            if (!HasIntersection && (ShapeType1 == "point" || ShapeType2 == "point"))
            {
                return $"The {ShapeType1} cannot intersect the {ShapeType2}";
            }
            
            if (HasIntersection && Points.Count > 0)
            {
                var pointsStr = Points.Count == 1 
                    ? Points[0].ToString() 
                    : string.Join(" and ", Points.Select(p => p.ToString()));
                    
                return $"The {ShapeType1} and the {ShapeType2} have intersection at {pointsStr}";
            }
            
            return $"{ShapeType1} and {ShapeType2} do not have intersections";
        }
    }
}