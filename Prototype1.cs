using System;
using System.Collections.Generic;

// Prototype
public interface ICloneable
{
    ICloneable Clone();
    void Display();
}

// Prototype 1
public class ConcretePrototype1 : ICloneable
{
    private string attribute;

    public ConcretePrototype1(string attribute)
    {
        this.attribute = attribute;
    }

    public ICloneable Clone()
    {
        return new ConcretePrototype1(attribute);
    }

    public void Display()
    {
        Console.WriteLine($"ConcretePrototype1 with attribute: {attribute}");
    }
}

//Prototype 2
public class ConcretePrototype2 : ICloneable
{
    private int number;

    public ConcretePrototype2(int number)
    {
        this.number = number;
    }

    public ICloneable Clone()
    {
        return new ConcretePrototype2(number);
    }

    public void Display()
    {
        Console.WriteLine($"ConcretePrototype2 with number: {number}");
    }
}

class Program
{
    static void Main()
    {
        List<ICloneable> prototypes = new List<ICloneable>
        {
            new ConcretePrototype1("Attribute1"),
            new ConcretePrototype2(42)
        };

        foreach (var prototype in prototypes)
        {
            var clonedPrototype = prototype.Clone();
            ((ICloneable)clonedPrototype).Display();
        }

        Console.ReadLine();
    }
}
