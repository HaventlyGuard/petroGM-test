namespace GeometryTest.Factory
{
    public class ShapeFactoryTests
    {
        private readonly ShapeFactory _factory = new();
        
        [Fact]
        public void CreateFromString_Point_ReturnsPoint()
        {
            var shape = _factory.CreateFromString("point 1 2");
            
            Assert.IsType<Point>(shape);
            var point = (Point)shape;
            Assert.Equal(1, point.X);
            Assert.Equal(2, point.Y);
        }
        
        [Fact]
        public void CreateFromString_Rect_ReturnsRect()
        {
            var shape = _factory.CreateFromString("rect 1 2 3 4");
            
            Assert.IsType<Rect>(shape);
            var rect = (Rect)shape;
            Assert.Equal(1, rect.Left);
            Assert.Equal(2, rect.Top);
            Assert.Equal(3, rect.Right);
            Assert.Equal(4, rect.Bottom);
        }
        
        [Fact]
        public void CreateFromString_Line_ReturnsLine()
        {
            var shape = _factory.CreateFromString("line 10 10 20 20");
            
            Assert.IsType<Line>(shape);
            var line = (Line)shape;
            Assert.Equal(10, line.pointA.X);
            Assert.Equal(10, line.pointA.Y);
            Assert.Equal(20, line.pointB.X);
            Assert.Equal(20, line.pointB.Y);
        }
        
        [Fact]
        public void CreateFromString_Circle_ReturnsCircle()
        {
            var shape = _factory.CreateFromString("circle 10 10 5");
            
            Assert.IsType<Circle>(shape);
            var circle = (Circle)shape;
            Assert.Equal(10, circle.Center.X);
            Assert.Equal(10, circle.Center.Y);
            Assert.Equal(5, circle.Radius);
        }
        
        [Fact]
        public void CreateFromString_CaseInsensitive()
        {
            var shape = _factory.CreateFromString("CIRCLE 10 10 5");
            
            Assert.IsType<Circle>(shape);
        }
        
        [Fact]
        public void CreateFromString_UnknownType_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _factory.CreateFromString("triangle 0 0 1 1 2 0"));
        }
        
        [Fact]
        public void CreateFromString_InvalidFormat_ThrowsException()
        {
            Assert.Throws<FormatException>(() => _factory.CreateFromString("point 1"));
        }
        
        [Fact]
        public void CreateFromString_EmptyString_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _factory.CreateFromString(""));
        }
        
        [Fact]
        public void CreateFromString_NullString_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _factory.CreateFromString(null!));
        }
    }
}