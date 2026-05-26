namespace GeometryTest.Core;

public class PointDTests
{
    [Fact]
    public void ConstructorTest()
    {
        var point = new PointD(10, 7.2);
        Assert.Equal(10, point.X);
        Assert.Equal(7.2, point.Y);
    }
    
    [Fact]
    public void ToString_ReturnsFormattedPoint()
    {
        var point = new PointD(1.5, 2.5);
            
        var result = point.ToString();
            
        Assert.Equal("(1.50, 2.50)", result);
    }
        
    [Fact]
    public void Equals_True_ForSameCoordinates()
    {
        var point1 = new PointD(1, 2);
        var point2 = new PointD(1, 2);
            
        Assert.Equal(point1, point2);
        Assert.True(point1 == point2);
    }
        
    [Fact]
    public void Equals_False_ForDifferentCoordinates()
    {
        var point1 = new PointD(1, 2);
        var point2 = new PointD(3, 4);
            
        Assert.NotEqual(point1, point2);
        Assert.True(point1 != point2);
    }
}