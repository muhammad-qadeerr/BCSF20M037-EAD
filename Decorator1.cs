using System;

namespace DecoratorPattern
{ 
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }


    public class SimpleCoffee : ICoffee
    {
        public string GetDescription()
        {
            return "Simple Coffee";
        }

        public double GetCost()
        {
            return 2.0;
        }
    }

    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee decoratedCoffee;

        public CoffeeDecorator(ICoffee coffee)
        {
            this.decoratedCoffee = coffee;
        }

        public virtual string GetDescription()
        {
            return decoratedCoffee.GetDescription();
        }

        public virtual double GetCost()
        {
            return decoratedCoffee.GetCost();
        }
    }

    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee)
        {
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, Milk";
        }

        public override double GetCost()
        {
            return base.GetCost() + 1.0;
        }
    }
    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee)
        {
        }

        public override string GetDescription()
        {
            return $"{base.GetDescription()}, Sugar";
        }

        public override double GetCost()
        {
            return base.GetCost() + 0.5;
        }
    }

    class Program
    {
        static void Main()
        {
          
            ICoffee simpleCoffee = new SimpleCoffee();
            Console.WriteLine($"Description: {simpleCoffee.GetDescription()}, Cost: ${simpleCoffee.GetCost()}");

       
            ICoffee coffeeWithMilk = new MilkDecorator(simpleCoffee);
            Console.WriteLine($"Description: {coffeeWithMilk.GetDescription()}, Cost: ${coffeeWithMilk.GetCost()}");

      
            ICoffee coffeeWithMilkAndSugar = new SugarDecorator(coffeeWithMilk);
            Console.WriteLine($"Description: {coffeeWithMilkAndSugar.GetDescription()}, Cost: ${coffeeWithMilkAndSugar.GetCost()}");

            Console.ReadLine();
        }
    }

}