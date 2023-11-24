using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_Pattern
{

    // Component interface
    public interface IGraphic
    {
        void Draw();
    }

    // Leaf
    public class Circle : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Circle");
        }
    }

    // Leaf
    public class Square : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Square");
        }
    }

    // Composite
    public class CompositeGraphic : IGraphic
    {
        private readonly List<IGraphic> graphics = new List<IGraphic>();

        public void Add(IGraphic graphic)
        {
            graphics.Add(graphic);
        }

        public void Draw()
        {
            foreach (var graphic in graphics)
            {
                graphic.Draw();
            }
        }
    }

    // Client code
    class Program
    {
        static void Main()
        {
            IGraphic circle = new Circle();
            IGraphic square = new Square();

            CompositeGraphic composite = new CompositeGraphic();
            composite.Add(circle);
            composite.Add(square);

            composite.Draw();

            Console.ReadLine();
        }
    }

}
