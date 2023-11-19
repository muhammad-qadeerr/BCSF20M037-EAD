using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Pattern
{

    public interface ICarMaker
    {
        void GetBrandName();
        void GetPrice();
        void GetColors();
    }


    public class FactoryMaker
    {
        public static ICarMaker GetCar(string name)
        {
            if (name == "BMW")
            {
                return new BMW();
            }
            else if (name == "Toyota")
            {
                return new Toyota();
            }
            else if (name == "Honda")
            {
                return new Honda();
            }
            return null;
        }
    }

    public class BMW : ICarMaker
    {
        public void GetBrandName()
        {
            Console.WriteLine("This is BMW");
        }

        public void GetColors()
        {
            Console.WriteLine("Red Green Blue");
        }

        public void GetPrice()
        {
            Console.WriteLine("2300");
        }
    }
    public class Toyota : ICarMaker
    {
        public void GetBrandName()
        {
            Console.WriteLine("This is Toyota");
        }

        public void GetColors()
        {
            Console.WriteLine ("Black Yellow Blue");
        }

        public void GetPrice()
        {
            Console.WriteLine("2500");
        }
    }
    public class Honda : ICarMaker
    {
        public void GetBrandName()
        {
            Console.WriteLine("This is Honda");
        }

        public void GetColors()
        {
            Console.WriteLine("Pink White Gray");
        }

        public void GetPrice()
        {
            Console.WriteLine("2700");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var bmw = FactoryMaker.GetCar("BMW");
            bmw.GetBrandName();
            bmw.GetPrice();
            bmw.GetColors();
            var toyota = FactoryMaker.GetCar("Toyota");
            toyota.GetBrandName();
            toyota.GetPrice();
            toyota.GetColors();

        }
    }
}
