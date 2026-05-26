using System;
using System.Globalization;
using GeometryLib.Core;
using GeometryLib.Features.Point;
using GeometryLib.Features.Rect;
using GeometryLib.Features.Line;
using GeometryLib.Features.Circle;

namespace GeometryLib.Factory
{
    public class ShapeFactory : IShapeFactory
    {
        public IShape CreateFromString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input string cannot be null or empty");

            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            if (parts.Length == 0)
                throw new ArgumentException("Input string has no data");

            var type = parts[0].ToLowerInvariant().Trim();

            return type switch
            {
                "point" => ParsePoint(parts),
                "rect" => ParseRect(parts),
                "line" => ParseLine(parts),
                "circle" => ParseCircle(parts),
                _ => throw new ArgumentException($"Unknown shape type: '{type}'. Supported types: point, rect, line, circle")
            };
        }

        private IShape ParsePoint(string[] parts)
        {
            if (parts.Length != 3)
                throw new FormatException($"Point expects 2 coordinates, but got {parts.Length - 1}. Format: point x y");

            if (!TryParseDouble(parts[1], out double x))
                throw new FormatException($"Invalid X coordinate for point: '{parts[1]}'");

            if (!TryParseDouble(parts[2], out double y))
                throw new FormatException($"Invalid Y coordinate for point: '{parts[2]}'");

            return new Point(new PointD(x,y));
        }

        private IShape ParseRect(string[] parts)
        {
            if (parts.Length != 5)
                throw new FormatException($"Rect expects 4 coordinates, but got {parts.Length - 1}. Format: rect x1 y1 x2 y2");

            if (!TryParseDouble(parts[1], out double x1))
                throw new FormatException($"Invalid X1 coordinate for rect: '{parts[1]}'");

            if (!TryParseDouble(parts[2], out double y1))
                throw new FormatException($"Invalid Y1 coordinate for rect: '{parts[2]}'");

            if (!TryParseDouble(parts[3], out double x2))
                throw new FormatException($"Invalid X2 coordinate for rect: '{parts[3]}'");

            if (!TryParseDouble(parts[4], out double y2))
                throw new FormatException($"Invalid Y2 coordinate for rect: '{parts[4]}'");

            return new Rect(x1, y1, x2, y2);
        }

        private IShape ParseLine(string[] parts)
        {
            if (parts.Length != 5)
                throw new FormatException($"Line expects 4 coordinates, but got {parts.Length - 1}. Format: line x1 y1 x2 y2");

            if (!TryParseDouble(parts[1], out double x1))
                throw new FormatException($"Invalid X1 coordinate for line: '{parts[1]}'");

            if (!TryParseDouble(parts[2], out double y1))
                throw new FormatException($"Invalid Y1 coordinate for line: '{parts[2]}'");

            if (!TryParseDouble(parts[3], out double x2))
                throw new FormatException($"Invalid X2 coordinate for line: '{parts[3]}'");

            if (!TryParseDouble(parts[4], out double y2))
                throw new FormatException($"Invalid Y2 coordinate for line: '{parts[4]}'");

            return new Line(new PointD(x1,y1),new PointD(x2,y2));
        }

        private IShape ParseCircle(string[] parts)
        {
            if (parts.Length != 4)
                throw new FormatException($"Circle expects center coordinates and radius, but got {parts.Length - 1} values. Format: circle x y radius");

            if (!TryParseDouble(parts[1], out double x))
                throw new FormatException($"Invalid X coordinate for circle: '{parts[1]}'");

            if (!TryParseDouble(parts[2], out double y))
                throw new FormatException($"Invalid Y coordinate for circle: '{parts[2]}'");

            if (!TryParseDouble(parts[3], out double radius))
                throw new FormatException($"Invalid radius for circle: '{parts[3]}'");

            if (radius < 0)
                throw new FormatException($"Circle radius cannot be negative: {radius}");

            return new Circle(x, y, radius);
        }

      
        private static bool TryParseDouble(string value, out double result)
        {
            if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out result))
                return true;

            if (double.TryParse(value, NumberStyles.Float, CultureInfo.CurrentCulture, out result))
                return true;

            return false;
        }
    }
}