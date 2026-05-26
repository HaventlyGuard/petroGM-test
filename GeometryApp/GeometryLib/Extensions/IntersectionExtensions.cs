using GeometryLib.Core;
using GeometryLib.Services;

namespace GeometryLib.Extensions
{
    public static class IntersectionExtensions
    {

        public static IntersectionResult IntersectWith(this IShape shape1, IShape shape2)
        {
            return IntersectionService.Intersect(shape1, shape2);
        }
    }
}