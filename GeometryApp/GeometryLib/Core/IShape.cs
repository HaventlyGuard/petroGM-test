using GeometryLib.Core;

namespace GeometryLib.Core
{
    public interface IShape
    {
        string Draw();
        string ShapeType { get; }
    }
}