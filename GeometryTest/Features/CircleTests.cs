namespace GeometryTest.Features
{
    public class CircleTests
    {
        [Fact]
        public void Draw_ReturnsCorrectString()
        {
            var circle = new Circle(new PointD(-100, 300), 50);
            
            var result = circle.Draw();
            
            Assert.Equal("circle at (-100.00, 300.00), radius = 50", result);
        }
        
        [Fact]
        public void ShapeType_ReturnsCircle()
        {
            var circle = new Circle(new PointD(0, 0), 10);
            
            Assert.Equal("circle", circle.ShapeType);
        }
        
        [Fact]
        public void Constructor_WithDoubles_CreatesCorrectCircle()
        {
            var circle = new Circle(5, 5, 10);
            
            Assert.Equal(5, circle.Center.X);
            Assert.Equal(5, circle.Center.Y);
            Assert.Equal(10, circle.Radius);
        }
    }
}