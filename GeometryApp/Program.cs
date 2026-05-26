using GeometryLib.Core;
using GeometryLib.Factory;
using GeometryLib.Extensions;
using GeometryLib.Services;

namespace GeometryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "input.txt";
            
            if (args.Length > 0)
            {
                filePath = args[0];
            }

            Console.WriteLine($"Reading shapes from: {filePath}");
            Console.WriteLine();

            try
            {
                var factory = new ShapeFactory();
                var shapes = new List<IShape>();

                string[] lines = File.ReadAllLines(filePath);
                
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    try
                    {
                        IShape shape = factory.CreateFromString(line.Trim());
                        shapes.Add(shape);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Warning: Could not parse line '{line}': {ex.Message}");
                    }
                }

                if (shapes.Count == 0)
                {
                    Console.WriteLine("No valid shapes found in file.");
                    return;
                }

                Console.WriteLine($"Successfully created {shapes.Count} shapes.");
                Console.WriteLine();

                Console.WriteLine("=== DRAW ===");
                foreach (IShape shape in shapes)
                {
                    Console.WriteLine(shape.Draw());
                }

                Console.WriteLine();
                Console.WriteLine("=== INTERSECTIONS ===");
                
                for (int i = 0; i < shapes.Count - 1; i++)
                {
                    IShape shape1 = shapes[i];
                    IShape shape2 = shapes[i + 1];
                    
                    IntersectionResult result = IntersectionService.Intersect(shape1, shape2);
                    Console.WriteLine(result.ToMessage());
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: File not found: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}