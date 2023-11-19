using System;

// Product
public class Product
{
    private string partA;
    private string partB;
    private string partC;

    public void AddPartA(string part)
    {
        partA = part;
    }

    public void AddPartB(string part)
    {
        partB = part;
    }

    public void AddPartC(string part)
    {
        partC = part;
    }

    public void Display()
    {
        Console.WriteLine($"Product Parts: {partA}, {partB}, {partC}");
    }
}

// Builder
public interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    void BuildPartC();
    Product GetResult();
}

// Concrete Builder 1
public class Builder1 : IBuilder
{
    private Product product = new Product();

    public void BuildPartA()
    {
        product.AddPartA("PartA1");
    }

    public void BuildPartB()
    {
        product.AddPartB("PartB1");
    }

    public void BuildPartC()
    {
        product.AddPartC("PartC1");
    }

    public Product GetResult()
    {
        return product;
    }
}

// Concrete Builder 2
public class Builder2 : IBuilder
{
    private Product product = new Product();

    public void BuildPartA()
    {
        product.AddPartA("PartA2");
    }

    public void BuildPartB()
    {
        product.AddPartB("PartB2");
    }

    public void BuildPartC()
    {
        product.AddPartC("PartC2");
    }

    public Product GetResult()
    {
        return product;
    }
}

// Director
public class Director
{
    public void Construct(IBuilder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
        builder.BuildPartC();
    }
}

class Program
{
    static void Main()
    {
        Director director = new Director();

        IBuilder builder1 = new Builder1();
        director.Construct(builder1);
        Product product1 = builder1.GetResult();
        product1.Display();

        IBuilder builder2 = new Builder2();
        director.Construct(builder2);
        Product product2 = builder2.GetResult();
        product2.Display();

        Console.ReadLine();
    }
}
