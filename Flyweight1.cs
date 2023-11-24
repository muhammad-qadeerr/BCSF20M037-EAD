using System;
using System.Diagnostics;

namespace FlyweightPattern
{

    static class FlyWeightFactory
    {
        private static Dictionary<string, Flyweight> _flyWeights = new Dictionary<string, Flyweight>(); 
        
        public static Flyweight GetFlyweight(string property1)
        {
            if(_flyWeights.ContainsKey(property1))
            {
                return _flyWeights[property1];
            }
            else
            {
                _flyWeights.Add(property1 , new SharedFlyWeight(property1));
                return _flyWeights[property1];
            }


        }
    
    }

    interface Flyweight
    {

    }

    class SharedFlyWeight : Flyweight
    {

        // Intrinsic State = shared
        string property1;
        string property2;
        string property3;
        string property4;

        public SharedFlyWeight(string property1)
        {
            this.property1 = property1;
            this.property2 = property1 + "Something Else!";
            this.property3 = property2 + "Something Else!";
            this.property4 = property1 + property2;
        }
    }


    class Context
    {
        // Extrinsic State = unsahared
        string ID;

        Flyweight flyWeight;
       

        public Context( string _property1)
        {
           this.flyWeight = FlyWeightFactory.GetFlyweight(_property1);

            this.ID = DateTime.Now.GetHashCode().ToString("x");
        }




    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Context> contexts = new List<Context>();

            for(int i = 0; i<10000; i++)
            {
                Context context = new Context("Argument");
                contexts.Add(context);
            }

            Console.WriteLine(contexts.Count);
            Console.ReadLine();
         
        }
    }
}