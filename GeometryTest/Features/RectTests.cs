namespace GeometryTest.Features
{
    public class RectTests
    {
        [Fact]
        public void Draw_ReturnsCorrectString()
        {
            var rect = new Rect(new PointD(1, 2), new PointD(3, 4));
            
            var result = rect.Draw();
            
            Assert.Equal("rect at (1.00, 2.00), (3.00, 4.00)", result);
        }
        
        [Fact]
        public void NormalizesCoordinates()
        {
            var rect = new Rect(new PointD(10, 10), new PointD(0, 0));
            
            Assert.Equal(0, rect.Left);
            Assert.Equal(0, rect.Top);
            Assert.Equal(10, rect.Right);
            Assert.Equal(10, rect.Bottom);
        }
        
        [Fact]
        public void GetEdges_ReturnsFourEdges()
        {
            var rect = new Rect(new PointD(0, 0), new PointD(2, 2));
            
            var edges = rect.GetEdges();
            
            Assert.Equal(4, edges.Length);
        }
        
        [Fact]
        public void Width_ReturnsCorrectValue()
        {
            var rect = new Rect(new PointD(0, 0), new PointD(5, 10));
            
            Assert.Equal(5, rect.Width);
            Assert.Equal(10, rect.Height);
        }
        
        [Fact]
        public void Constructor_WithDoubles_CreatesCorrectRect()
        {
            var rect = new Rect(1, 2, 3, 4);
            
            Assert.Equal(1, rect.Left);
            Assert.Equal(2, rect.Top);
            Assert.Equal(3, rect.Right);
            Assert.Equal(4, rect.Bottom);
        }
    }
}