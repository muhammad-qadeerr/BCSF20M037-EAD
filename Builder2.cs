using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    using System;

    // Product
    public class Meal
    {
        private string mainCourse;
        private string drink;
        private string dessert;

        public void AddMainCourse(string mainCourse)
        {
            this.mainCourse = mainCourse;
        }

        public void AddDrink(string drink)
        {
            this.drink = drink;
        }

        public void AddDessert(string dessert)
        {
            this.dessert = dessert;
        }

        public void Display()
        {
            Console.WriteLine($"Meal: {mainCourse}, {drink}, {dessert}");
        }
    }

    // Builder
    public interface IMealBuilder
    {
        void BuildMainCourse();
        void BuildDrink();
        void BuildDessert();
        Meal GetResult();
    }

    // Concrete Builder for a Healthy Meal
    public class HealthyMealBuilder : IMealBuilder
    {
        private Meal meal = new Meal();

        public void BuildMainCourse()
        {
            meal.AddMainCourse("Grilled Chicken Salad");
        }

        public void BuildDrink()
        {
            meal.AddDrink("Water");
        }

        public void BuildDessert()
        {
            meal.AddDessert("Fruit Salad");
        }

        public Meal GetResult()
        {
            return meal;
        }
    }

    // Concrete Builder for a Fast Food Meal
    public class FastFoodMealBuilder : IMealBuilder
    {
        private Meal meal = new Meal();

        public void BuildMainCourse()
        {
            meal.AddMainCourse("Cheeseburger");
        }

        public void BuildDrink()
        {
            meal.AddDrink("Cola");
        }

        public void BuildDessert()
        {
            meal.AddDessert("Apple Pie");
        }

        public Meal GetResult()
        {
            return meal;
        }
    }

    // Director
    public class Waiter
    {
        public void Construct(IMealBuilder builder)
        {
            builder.BuildMainCourse();
            builder.BuildDrink();
            builder.BuildDessert();
        }
    }

    class Program
    {
        static void Main()
        {
            Waiter waiter = new Waiter();

            // Construct a Healthy Meal
            IMealBuilder healthyMealBuilder = new HealthyMealBuilder();
            waiter.Construct(healthyMealBuilder);
            Meal healthyMeal = healthyMealBuilder.GetResult();
            healthyMeal.Display();

            // Construct a Fast Food Meal
            IMealBuilder fastFoodMealBuilder = new FastFoodMealBuilder();
            waiter.Construct(fastFoodMealBuilder);
            Meal fastFoodMeal = fastFoodMealBuilder.GetResult();
            fastFoodMeal.Display();

            Console.ReadLine();
        }
    }

}

