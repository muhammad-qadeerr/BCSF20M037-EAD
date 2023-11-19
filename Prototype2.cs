using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_Pattern
{

    // Prototype interface
    public interface IAnimalCloneable
    {
        IAnimalCloneable Clone();
        void Display();
    }

    // Prototype for Dog
    public class Dog : IAnimalCloneable
    {
        private string breed;

        public Dog(string breed)
        {
            this.breed = breed;
        }

        public IAnimalCloneable Clone()
        {
            return new Dog(breed);
        }

        public void Display()
        {
            Console.WriteLine($"Dog of breed: {breed}");
        }
    }

    // Prototype for Cat
    public class Cat : IAnimalCloneable
    {
        private string color;

        public Cat(string color)
        {
            this.color = color;
        }

        public IAnimalCloneable Clone()
        {
            return new Cat(color);
        }

        public void Display()
        {
            Console.WriteLine($"Cat with color: {color}");
        }
    }

    class Program
    {
        static void Main()
        {
            List<IAnimalCloneable> animalPrototypes = new List<IAnimalCloneable>
        {
            new Dog("Labrador"),
            new Cat("Gray")
        };

            foreach (var prototype in animalPrototypes)
            {
                var clonedAnimal = prototype.Clone();
                ((IAnimalCloneable)clonedAnimal).Display();
            }

            Console.ReadLine();
        }
    }
}
