using GeometryLib.Core;
using GeometryLib.Features.Point;
using GeometryLib.Features.Line;
using GeometryLib.Features.Rect;
using GeometryLib.Features.Circle;

namespace GeometryLib.Services
{
    public static class IntersectionService
    {
        private const double Epsilon = 1e-9;
        
   
        public static IntersectionResult Intersect(IShape shape1, IShape shape2)
        {
            if (shape1 is Point || shape2 is Point)
            {
                return IntersectionResult.CannotIntersect(shape1.ShapeType, shape2.ShapeType);
            }
            
            return (shape1, shape2) switch
            {
                (Line line1, Line line2) => IntersectLineWithLine(line1, line2),
                (Line line, Circle circle) => IntersectLineWithCircle(line, circle),
                (Circle circle, Line line) => IntersectLineWithCircle(line, circle),
                
                (Line line, Rect rect) => IntersectLineWithRect(line, rect),
                (Rect rect, Line line) => IntersectLineWithRect(line, rect),
                
                (Circle circle1, Circle circle2) => IntersectCircleWithCircle(circle1, circle2),
                
                (Circle circle, Rect rect) => IntersectCircleWithRect(circle, rect),
                (Rect rect, Circle circle) => IntersectCircleWithRect(circle, rect),
                
                (Rect rect1, Rect rect2) => IntersectRectWithRect(rect1, rect2),
                
                _ => IntersectionResult.NoIntersection(shape1.ShapeType, shape2.ShapeType)
            };
        }
        
        
        private static IntersectionResult IntersectLineWithLine(Line line1, Line line2)
        {
            double denominator = line1.A * line2.B - line2.A * line1.B;
            
            if (Math.Abs(denominator) < Epsilon)
            {
                return IntersectionResult.NoIntersection(line1.ShapeType, line2.ShapeType);
            }
            
            double x = (line1.B * line2.C - line2.B * line1.C) / denominator;
            double y = (line2.A * line1.C - line1.A * line2.C) / denominator;
            
            if (IsPointOnSegment(x, y, line1) && IsPointOnSegment(x, y, line2))
            {
                return IntersectionResult.Intersects(
                    line1.ShapeType, 
                    line2.ShapeType, 
                    new PointD(x, y));
            }
            
            return IntersectionResult.NoIntersection(line1.ShapeType, line2.ShapeType);
        }
        
        
        private static IntersectionResult IntersectLineWithCircle(Line line, Circle circle)
        {
            double x1 = line.X1 - circle.X;
            double y1 = line.Y1 - circle.Y;
            double x2 = line.X2 - circle.X;
            double y2 = line.Y2 - circle.Y;
            
            double dx = x2 - x1;
            double dy = y2 - y1;
            
            double a = dx * dx + dy * dy;
            double b = 2 * (x1 * dx + y1 * dy);
            double c = x1 * x1 + y1 * y1 - circle.Radius * circle.Radius;
            
            double discriminant = b * b - 4 * a * c;
            
            if (discriminant < -Epsilon)
            {
                return IntersectionResult.NoIntersection(line.ShapeType, circle.ShapeType);
            }
            
            var points = new List<PointD>();
            
            if (Math.Abs(discriminant) < Epsilon)
            {
                double t = -b / (2 * a);
                if (t >= 0 && t <= 1)
                {
                    points.Add(new PointD(x1 + t * dx + circle.X, y1 + t * dy + circle.Y));
                }
            }
            else
            {
                double sqrtD = Math.Sqrt(discriminant);
                double t1 = (-b + sqrtD) / (2 * a);
                double t2 = (-b - sqrtD) / (2 * a);
                
                if (t1 >= 0 && t1 <= 1)
                    points.Add(new PointD(x1 + t1 * dx + circle.X, y1 + t1 * dy + circle.Y));
                    
                if (t2 >= 0 && t2 <= 1)
                    points.Add(new PointD(x1 + t2 * dx + circle.X, y1 + t2 * dy + circle.Y));
            }
            
            if (points.Count > 0)
            {
                return IntersectionResult.Intersects(line.ShapeType, circle.ShapeType, points);
            }
            
            return IntersectionResult.NoIntersection(line.ShapeType, circle.ShapeType);
        }
        
        
        private static IntersectionResult IntersectLineWithRect(Line line, Rect rect)
        {
            var allPoints = new List<PointD>();
            
            foreach (var (start, end) in rect.GetEdges())
            {
                var edgeLine = new Line(start, end);
                var result = IntersectLineWithLine(line, edgeLine);
                
                if (result.HasIntersection)
                {
                    allPoints.AddRange(result.Points);
                }
            }
            
            var uniquePoints = allPoints.Distinct().ToList();
            
            if (uniquePoints.Count > 0)
            {
                return IntersectionResult.Intersects(line.ShapeType, rect.ShapeType, uniquePoints);
            }
            
            return IntersectionResult.NoIntersection(line.ShapeType, rect.ShapeType);
        }
        
        
        private static IntersectionResult IntersectCircleWithCircle(Circle circle1, Circle circle2)
        {
            double dx = circle2.X - circle1.X;
            double dy = circle2.Y - circle1.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);
            
            if (distance > circle1.Radius + circle2.Radius + Epsilon ||
                distance < Math.Abs(circle1.Radius - circle2.Radius) - Epsilon)
            {
                return IntersectionResult.NoIntersection(circle1.ShapeType, circle2.ShapeType);
            }
            
            if (Math.Abs(distance - (circle1.Radius + circle2.Radius)) < Epsilon)
            {
                double t = circle1.Radius / (circle1.Radius + circle2.Radius);
                var point = new PointD(
                    circle1.X + t * dx,
                    circle1.Y + t * dy);
                return IntersectionResult.Intersects(circle1.ShapeType, circle2.ShapeType, point);
            }
            
            if (Math.Abs(distance - Math.Abs(circle1.Radius - circle2.Radius)) < Epsilon)
            {
                double t = circle1.Radius / distance;
                var point = new PointD(
                    circle1.X + t * dx,
                    circle1.Y + t * dy);
                return IntersectionResult.Intersects(circle1.ShapeType, circle2.ShapeType, point);
            }
            
            double a = (circle1.Radius * circle1.Radius - circle2.Radius * circle2.Radius + distance * distance) / (2 * distance);
            double h = Math.Sqrt(circle1.Radius * circle1.Radius - a * a);
            
            double px = circle1.X + a * dx / distance;
            double py = circle1.Y + a * dy / distance;
            
            var point1 = new PointD(
                px + h * dy / distance,
                py - h * dx / distance);
                
            var point2 = new PointD(
                px - h * dy / distance,
                py + h * dx / distance);
                
            return IntersectionResult.Intersects(circle1.ShapeType, circle2.ShapeType, point1, point2);
        }
        
        
        private static IntersectionResult IntersectCircleWithRect(Circle circle, Rect rect)
        {
            var allPoints = new List<PointD>();
            
            foreach (var (start, end) in rect.GetEdges())
            {
                var edgeLine = new Line(start, end);
                var result = IntersectLineWithCircle(edgeLine, circle);
                
                if (result.HasIntersection)
                {
                    allPoints.AddRange(result.Points);
                }
            }
            
            var uniquePoints = allPoints.Distinct().ToList();
            
            if (uniquePoints.Count > 0)
            {
                return IntersectionResult.Intersects(circle.ShapeType, rect.ShapeType, uniquePoints);
            }
            
            return IntersectionResult.NoIntersection(circle.ShapeType, rect.ShapeType);
        }
        
        
        private static IntersectionResult IntersectRectWithRect(Rect rect1, Rect rect2)
        {
            var allPoints = new List<PointD>();
            
            foreach (var (start, end) in rect1.GetEdges())
            {
                var edgeLine = new Line(start, end);
                var result = IntersectLineWithRect(edgeLine, rect2);
                
                if (result.HasIntersection)
                {
                    allPoints.AddRange(result.Points);
                }
            }
            
            var uniquePoints = allPoints.Distinct().ToList();
            
            if (uniquePoints.Count > 0)
            {
                return IntersectionResult.Intersects(rect1.ShapeType, rect2.ShapeType, uniquePoints);
            }
            
            return IntersectionResult.NoIntersection(rect1.ShapeType, rect2.ShapeType);
        }
        
   
        private static bool IsPointOnSegment(double x, double y, Line line)
        {
            return x >= Math.Min(line.X1, line.X2) - Epsilon &&
                   x <= Math.Max(line.X1, line.X2) + Epsilon &&
                   y >= Math.Min(line.Y1, line.Y2) - Epsilon &&
                   y <= Math.Max(line.Y1, line.Y2) + Epsilon;
        }
    }
}