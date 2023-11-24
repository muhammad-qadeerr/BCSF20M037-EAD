using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_Pattern
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
        void RenderSquare(float side);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius} using vector renderer");
        }

        public void RenderSquare(float side)
        {
            Console.WriteLine($"Drawing a square of side {side} using vector renderer");
        }
    }
    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius} using raster renderer");
        }

        public void RenderSquare(float side)
        {
            Console.WriteLine($"Drawing a square of side {side} using raster renderer");
        }
    }

    public abstract class Shape
    {
        protected IRenderer renderer;

        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Draw();
    }
    public class Circle : Shape
    {
        private readonly float radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }
    }
    public class Square : Shape
    {
        private readonly float side;

        public Square(IRenderer renderer, float side) : base(renderer)
        {
            this.side = side;
        }

        public override void Draw()
        {
            renderer.RenderSquare(side);
        }
    }

    class Program
    {
        static void Main()
        {
            // Create different renderers
            IRenderer vectorRenderer = new VectorRenderer();
            IRenderer rasterRenderer = new RasterRenderer();

            // Create different shapes with different renderers
            Shape circle1 = new Circle(vectorRenderer, 5);
            Shape circle2 = new Circle(rasterRenderer, 8);
            Shape square1 = new Square(vectorRenderer, 4);
            Shape square2 = new Square(rasterRenderer, 6);

            // Draw the shapes
            circle1.Draw();
            circle2.Draw();
            square1.Draw();
            square2.Draw();

            Console.ReadLine();
        }
    }

}
