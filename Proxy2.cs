using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Pattern
{
    public interface IImage
    {
        void Display();
    }

    // RealSubject
    public class RealImage : IImage
    {
        private readonly string filename;

        public RealImage(string filename)
        {
            this.filename = filename;
            LoadImage();
        }

        private void LoadImage()
        {
            Console.WriteLine($"Loading image: {filename}");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying image: {filename}");
        }
    }

    // Proxy
    public class ProxyImage : IImage
    {
        private RealImage realImage;
        private readonly string filename;

        public ProxyImage(string filename)
        {
            this.filename = filename;
        }

        public void Display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(filename);
            }
            realImage.Display();
        }
    }
    class Program
    {
        static void Main()
        {
            IImage image = new ProxyImage("example.jpg");
            image.Display();

            Console.ReadLine();
        }
    }

}

