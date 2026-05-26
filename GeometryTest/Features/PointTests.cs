namespace GeometryTest.Features
{
    public class PointTests
    {
        [Fact]
        public void Draw_ReturnsCorrectString()
        {
            var point = new Point(new PointD(10, 20));
            
            var result = point.Draw();
            
            Assert.Equal("point at (10.00, 20.00)", result);
        }
        
        [Fact]
        public void ShapeType_ReturnsPoint()
        {
            var point = new Point(new PointD(1,2));
            
            Assert.Equal("point", point.ShapeType);
        }
        
        [Fact]
        public void Constructor_FromPointD()
        {
            var position = new PointD(5, 5);
            var point = new Point(position);
            
            Assert.Equal(5, point.X);
            Assert.Equal(5, point.Y);
        }
    }
}