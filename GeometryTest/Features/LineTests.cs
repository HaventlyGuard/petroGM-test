namespace GeometryTest.Features
{
    public class LineTests
    {
        [Fact]
        public void Draw_ReturnsCorrectString()
        {
            var line = new Line(new PointD(0, 0), new PointD(10, 10));
            
            var result = line.Draw();
            
            Assert.Equal("line from (0.00, 0.00) to (10.00, 10.00)", result);
        }
        
        [Fact]
        public void ShapeType_ReturnsLine()
        {
            var line = new Line(new PointD(0, 0), new PointD(1, 1));
            
            Assert.Equal("line", line.ShapeType);
        }
        
        [Fact]
        public void Length_CalculatesCorrectly()
        {
            var line = new Line(new PointD(0, 0), new PointD(3, 4));
            
            var length = line.Length;
            
            Assert.Equal(5, length, 1e-9);
        }
        
        [Fact]
        public void Constructor_WithDoubles_CreatesCorrectLine()
        {
            var line = new Line(new PointD(1,2), new PointD(3, 4));
            
            Assert.Equal(1, line.pointA.X);
            Assert.Equal(2, line.pointA.Y);
            Assert.Equal(3, line.pointB.X);
            Assert.Equal(4, line.pointB.Y);
        }
    }
}