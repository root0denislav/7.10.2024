using System;

class TriangleArea
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());
        double area = a * h / 2;
        Console.WriteLine($"Triangle area = {area:F2}");
    }
}
