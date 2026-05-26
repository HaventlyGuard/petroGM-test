namespace GeometryTest.Core
{
    public class IntersectionResultTests
    {
        [Fact]
        public void Intersects_CreatesResultWithPoints()
        {
            var result = IntersectionResult.Intersects("line", "circle", 
                new PointD(1, 2), new PointD(3, 4));
            
            Assert.True(result.HasIntersection);
            Assert.Equal(2, result.Points.Count);
            Assert.Equal("line", result.ShapeType1);
            Assert.Equal("circle", result.ShapeType2);
        }
        
        [Fact]
        public void NoIntersection_CreatesResultWithoutPoints()
        {
            var result = IntersectionResult.NoIntersection("line", "rect");
            
            Assert.False(result.HasIntersection);
            Assert.Empty(result.Points);
        }
        
        [Fact]
        public void CannotIntersect_CreatesCorrectMessage()
        {
            var result = IntersectionResult.CannotIntersect("point", "circle");
            
            Assert.False(result.HasIntersection);
            Assert.Empty(result.Points);
        }
        
        [Fact]
        public void ToMessage_PointCannotIntersect()
        {
            var result = IntersectionResult.CannotIntersect("point", "circle");
            
            var message = result.ToMessage();
            
            Assert.Equal("The point cannot intersect the circle", message);
        }
        
        [Fact]
        public void ToMessage_HasIntersection_OnePoint()
        {
            var result = IntersectionResult.Intersects("line", "circle", new PointD(5, 10));
            
            var message = result.ToMessage();
            
            Assert.Contains("have intersection at", message);
            Assert.Contains("(5.00, 10.00)", message);
        }
        
        [Fact]
        public void ToMessage_NoIntersection()
        {
            var result = IntersectionResult.NoIntersection("line", "rect");
            
            var message = result.ToMessage();
            
            Assert.Equal("line and rect do not have intersections", message);
        }
    }
}