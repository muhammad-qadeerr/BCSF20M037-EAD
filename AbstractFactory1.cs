using System;

// Product A Interface to inherit Product A Classes
public interface IProductA
{
    void Display();
}

public class ProductA1 : IProductA
{
    public void Display()
    {
        Console.WriteLine("Product A1");
    }
}

public class ProductA2 : IProductA
{
    public void Display()
    {
        Console.WriteLine("Product A2");
    }
}

// Product B interface to inherit Product B classes.
public interface IProductB
{
    void Display();
}

// Concrete Product B1
public class ProductB1 : IProductB
{
    public void Display()
    {
        Console.WriteLine("Product B1");
    }
}

// Concrete Product B2
public class ProductB2 : IProductB
{
    public void Display()
    {
        Console.WriteLine("Product B2");
    }
}

// Factory interface inherits Factory classes.
public interface IFactory
{
    IProductA CreateProductA();
    IProductB CreateProductB();
}

public class Factory1 : IFactory
{
    public IProductA CreateProductA()
    {
        return new ProductA1();
    }

    public IProductB CreateProductB()
    {
        return new ProductB1();
    }
}

// Concrete Factory 2
public class Factory2 : IFactory
{
    public IProductA CreateProductA()
    {
        return new ProductA2();
    }

    public IProductB CreateProductB()
    {
        return new ProductB2();
    }
}

class Program
{
    static void Main()
    {
        IFactory factory1 = new Factory1();
        IProductA productA1 = factory1.CreateProductA();
        productA1.Display();

        IProductB productB1 = factory1.CreateProductB();
        productB1.Display();

        IFactory factory2 = new Factory2();
        IProductA productA2 = factory2.CreateProductA();
        productA2.Display();

        IProductB productB2 = factory2.CreateProductB();
        productB2.Display();

        Console.ReadLine();
    }
}
