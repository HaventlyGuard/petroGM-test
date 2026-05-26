using GeometryLib.Core;

namespace GeometryLib.Factory
{
    public interface IShapeFactory
    {
        IShape CreateFromString(string input);
    }
}