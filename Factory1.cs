using System;

// Product Interface to inherit any Product class.
public interface IProduct
{
    void Display();
}


public class ProductA : IProduct
{
    public void Display()
    {
        Console.WriteLine("Product A");
    }
}

public class ProductB : IProduct
{
    public void Display()
    {
        Console.WriteLine("Product B");
    }
}

// Factory Interface to inherit any Factory Class.
public interface IFactory
{
    IProduct CreateProduct();
}

public class FactoryA : IFactory
{
    public IProduct CreateProduct()
    {
        return new ProductA();
    }
}
public class FactoryB : IFactory
{
    public IProduct CreateProduct()
    {
        return new ProductB();
    }
}

class Program
{
    static void Main()
    {
        IFactory factoryA = new FactoryA();
        IProduct productA = factoryA.CreateProduct();
        productA.Display();

        IFactory factoryB = new FactoryB();
        IProduct productB = factoryB.CreateProduct();
        productB.Display();

        Console.ReadLine();
    }
}
