namespace GeometryTest.Services
{
    public class IntersectionServiceTests
    {
        
        [Fact]
        public void Point_WithAnyShape_ReturnsCannotIntersect()
        {
            var point = new Point(new PointD(1, 2));
            var line = new Line(new PointD(0, 0), new PointD(10, 10));
            
            var result = IntersectionService.Intersect(point, line);
            
            Assert.False(result.HasIntersection);
            Assert.Equal("point", result.ShapeType1);
        }
        
        
        [Fact]
        public void LineAndLine_Intersecting_ReturnsOnePoint()
        {
            var line1 = new Line(new PointD(0, 0), new PointD(10, 10));
            var line2 = new Line(new PointD(0, 10), new PointD(10, 0));
            
            var result = IntersectionService.Intersect(line1, line2);
            
            Assert.True(result.HasIntersection);
            Assert.Single(result.Points);
            Assert.Equal(5, result.Points[0].X, 1e-9);
            Assert.Equal(5, result.Points[0].Y, 1e-9);
        }
        
        [Fact]
        public void LineAndLine_Parallel_ReturnsNoIntersection()
        {
            var line1 = new Line(new PointD(0, 0), new PointD(10, 10));
            var line2 = new Line(new PointD(0, 1), new PointD(10, 11));
            
            var result = IntersectionService.Intersect(line1, line2);
            
            Assert.False(result.HasIntersection);
        }
        
        [Fact]
        public void LineAndLine_NotIntersectingSegments_ReturnsNoIntersection()
        {
            var line1 = new Line(new PointD(0, 0), new PointD(1, 1));
            var line2 = new Line(new PointD(10, 10), new PointD(11, 11));
            
            var result = IntersectionService.Intersect(line1, line2);
            
            Assert.False(result.HasIntersection);
        }
        
        
        [Fact]
        public void LineAndCircle_Intersecting_ReturnsTwoPoints()
        {
            var line = new Line(new PointD(0, 0), new PointD(10, 10));
            var circle = new Circle(new PointD(5, 5), 5);
            
            var result = IntersectionService.Intersect(line, circle);
            
            Assert.True(result.HasIntersection);
            Assert.Equal(2, result.Points.Count);
        }
        
        [Fact]
        public void LineAndCircle_Tangent_ReturnsOnePoint()
        {
            var line = new Line(new PointD(0, 5), new PointD(10, 5));
            var circle = new Circle(new PointD(5, 0), 5);
            
            var result = IntersectionService.Intersect(line, circle);
            
            Assert.True(result.HasIntersection);
            Assert.Single(result.Points);
        }
        
        [Fact]
        public void LineAndCircle_NoIntersection_ReturnsEmpty()
        {
            var line = new Line(new PointD(0, 0), new PointD(1, 1));
            var circle = new Circle(new PointD(100, 100), 5);
            
            var result = IntersectionService.Intersect(line, circle);
            
            Assert.False(result.HasIntersection);
        }
        
        
        [Fact]
        public void LineAndRect_Intersecting_ReturnsTwoPoints()
        {
            var line = new Line(new PointD(0, 5), new PointD(10, 5));
            var rect = new Rect(new PointD(2, 0), new PointD(8, 10));
            
            var result = IntersectionService.Intersect(line, rect);
            
            Assert.True(result.HasIntersection);
            Assert.Equal(2, result.Points.Count);
        }
        
        [Fact]
        public void LineAndRect_NoIntersection_ReturnsEmpty()
        {
            var line = new Line(new PointD(0, 0), new PointD(1, 1));
            var rect = new Rect(new PointD(10, 10), new PointD(20, 20));
            
            var result = IntersectionService.Intersect(line, rect);
            
            Assert.False(result.HasIntersection);
        }
        
        
        [Fact]
        public void CircleAndCircle_Intersecting_ReturnsTwoPoints()
        {
            var circle1 = new Circle(new PointD(0, 0), 5);
            var circle2 = new Circle(new PointD(6, 0), 5);
            
            var result = IntersectionService.Intersect(circle1, circle2);
            
            Assert.True(result.HasIntersection);
            Assert.Equal(2, result.Points.Count);
        }
        
        [Fact]
        public void CircleAndCircle_Separated_ReturnsNoIntersection()
        {
            var circle1 = new Circle(new PointD(0, 0), 5);
            var circle2 = new Circle(new PointD(100, 100), 5);
            
            var result = IntersectionService.Intersect(circle1, circle2);
            
            Assert.False(result.HasIntersection);
        }
        
        [Fact]
        public void CircleAndCircle_Tangent_ReturnsOnePoint()
        {
            var circle1 = new Circle(new PointD(0, 0), 5);
            var circle2 = new Circle(new PointD(10, 0), 5);
            
            var result = IntersectionService.Intersect(circle1, circle2);
            
            Assert.True(result.HasIntersection);
            Assert.Single(result.Points);
        }
        
        
        [Fact]
        public void CircleAndRect_Intersecting_ReturnsPoints()
        {
            var circle = new Circle(new PointD(5, 5), 5);
            var rect = new Rect(new PointD(0, 0), new PointD(10, 10));
            
            var result = IntersectionService.Intersect(circle, rect);
            
            Assert.True(result.HasIntersection);
        }
        
        
        [Fact]
        public void RectAndRect_Overlapping_ReturnsPoints()
        {
            var rect1 = new Rect(new PointD(0, 0), new PointD(5, 5));
            var rect2 = new Rect(new PointD(3, 3), new PointD(8, 8));
            
            var result = IntersectionService.Intersect(rect1, rect2);
            
            Assert.True(result.HasIntersection);
        }
        
        [Fact]
        public void RectAndRect_Separated_ReturnsNoIntersection()
        {
            var rect1 = new Rect(new PointD(0, 0), new PointD(2, 2));
            var rect2 = new Rect(new PointD(10, 10), new PointD(20, 20));
            
            var result = IntersectionService.Intersect(rect1, rect2);
            
            Assert.False(result.HasIntersection);
        }
    }
}