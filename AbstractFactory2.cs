using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Pattern
{
    // Interface for Garment Products
    public interface IGarment
    {
        void Display();
    }

    public class Shirt : IGarment
    {
        public void Display()
        {
            Console.WriteLine("Shirt");
        }
    }

    public class Jeans : IGarment
    {
        public void Display()
        {
            Console.WriteLine("Jeans");
        }
    }

    // Interface for Book Products
    public interface IBook
    {
        void Display();
    }

    public class Novel : IBook
    {
        public void Display()
        {
            Console.WriteLine("Novel");
        }
    }

    public class PoemBook : IBook
    {
        public void Display()
        {
            Console.WriteLine("Poem Book");
        }
    }

    // Factory interface inherits Factory classes.
    public interface IFactory
    {
        IGarment CreateGarment();
        IBook CreateBook();
    }

    // (Garment Factory)
    public class GarmentFactory : IFactory
    {
        public IGarment CreateGarment()
        {
            return new Shirt();
        }

        public IBook CreateBook()
        {
            return new Novel();
        }
    }

    // (Book Factory)
    public class BookFactory : IFactory
    {
        public IGarment CreateGarment()
        {
            return new Jeans();
        }

        public IBook CreateBook()
        {
            return new PoemBook();
        }
    }

    class Program
    {
        static void Main()
        {
            IFactory garmentFactory = new GarmentFactory();
            IGarment garment1 = garmentFactory.CreateGarment();
            garment1.Display();

            IBook book1 = garmentFactory.CreateBook(); // This may not make practical sense in a real scenario, but it illustrates the factory pattern very well.
            book1.Display();

            IFactory bookFactory = new BookFactory();
            IGarment garment2 = bookFactory.CreateGarment(); // Similarly, this may not make practical sense in a real scenario.
            garment2.Display();

            IBook book2 = bookFactory.CreateBook();
            book2.Display();

            Console.ReadLine();
        }
    }

}
