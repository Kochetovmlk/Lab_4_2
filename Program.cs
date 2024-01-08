using System;
using System.Collections.Generic;

class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string name, int productionYear, int maxSpeed)
    {
        Name = name;
        ProductionYear = productionYear;
        MaxSpeed = maxSpeed;
    }
}

class CarComparer : IComparer<Car>
{
    public enum ComparisonType
    {
        Name,
        ProductionYear,
        MaxSpeed
    }

    public ComparisonType CompareBy { get; set; }

    public int Compare(Car x, Car y)
    {
        

        switch (CompareBy)
        {
            case ComparisonType.Name:
                return string.Compare(x.Name, y.Name);
            case ComparisonType.ProductionYear:
                return x.ProductionYear.CompareTo(y.ProductionYear);
            case ComparisonType.MaxSpeed:
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            default:
                throw new ArgumentException("Недопустимый тип сравнения.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car[] cars = new Car[]
        {
            new Car("BMW", 2000, 150),
            new Car("Mercedes", 2010, 180),
            new Car("Ferrari", 1995, 130),
        };

        Console.WriteLine("Исходный массив:");
        PrintCarArray(cars);

        CarComparer comparer = new CarComparer();
        comparer.CompareBy = CarComparer.ComparisonType.Name;
        Array.Sort(cars, comparer);
        Console.WriteLine("\nСортировка по имени:");
        PrintCarArray(cars);

        comparer.CompareBy = CarComparer.ComparisonType.ProductionYear;
        Array.Sort(cars, comparer);
        Console.WriteLine("\nСортировка по году выпуска:");
        PrintCarArray(cars);

        comparer.CompareBy = CarComparer.ComparisonType.MaxSpeed;
        Array.Sort(cars, comparer);
        Console.WriteLine("\nСортировка по максимальной скорости:");
        PrintCarArray(cars);
    }

    static void PrintCarArray(Car[] cars)
    {
        foreach (Car car in cars)
        {
            Console.WriteLine($"{car.Name}, Год: {car.ProductionYear}, Максимальная скорость: {car.MaxSpeed} km/h");
        }
    }
}