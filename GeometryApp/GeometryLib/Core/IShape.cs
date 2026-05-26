using GeometryLib.Core;

namespace GeometryLib.Core
{
    public interface IShape
    {
        string Draw();
        IntersectionResult Intersect(IShape other);
    }
}