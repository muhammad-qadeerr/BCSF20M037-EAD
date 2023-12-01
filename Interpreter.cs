using System;
using System.Collections.Generic;

// Abstract Expression
public interface IDateExpression
{
    DateTime Interpret();
}

// Terminal Expression 1: Year
public class YearExpression : IDateExpression
{
    private readonly int _year;

    public YearExpression(int year)
    {
        _year = year;
    }

    public DateTime Interpret()
    {
        return new DateTime(_year, 1, 1);
    }
}

// Terminal Expression 2: Month
public class MonthExpression : IDateExpression
{
    private readonly IDateExpression _year;
    private readonly int _month;

    public MonthExpression(IDateExpression year, int month)
    {
        _year = year;
        _month = month;
    }

    public DateTime Interpret()
    {
        DateTime yearDate = _year.Interpret();
        return new DateTime(yearDate.Year, _month, 1);
    }
}

// Terminal Expression 3: Day
public class DayExpression : IDateExpression
{
    private readonly IDateExpression _month;
    private readonly int _day;

    public DayExpression(IDateExpression month, int day)
    {
        _month = month;
        _day = day;
    }

    public DateTime Interpret()
    {
        DateTime monthDate = _month.Interpret();
        return new DateTime(monthDate.Year, monthDate.Month, _day);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Interpret the date expression: year(2023), month(11), day(29)
        IDateExpression expression = new DayExpression(
            new MonthExpression(
                new YearExpression(2023),
                11),
            29);

        DateTime date = expression.Interpret();
        Console.WriteLine($"Interpreted Date: {date}");
        DateTime date1 = expression.Interpret();
        Console.WriteLine($"Interpreted Date: {date1}");

        //Console.ReadLine();
    }
}