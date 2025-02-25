﻿using System;
namespace lab1;
class Program
{
    static void Main(string[] args)
    {
        SolveQuadraticInteractive();
    }

    private static (double?, double?) SolveQuadratic(double a, double b, double c)
    {
        try
        {
            (double?, double?) answer = (null, null);
            double D = b * b - 4 * a * c;
            if (D == 0)
            {
                answer = (-b / (2 * a), null);
            }
            else if (D > 0)
            {
                var root1 = (-b + Math.Sqrt(D)) / (2 * a);
                var root2 = (-b - Math.Sqrt(D)) / (2 * a);
                answer = (root1, root2);
            }
            return answer;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occurred while trying to solve quadratic equation: " + e);
            throw;
        }
    }

    static double ReadDouble(string variable)
    {
        while (true)
        {
            string? input;
            Console.Write($"{variable} = ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double value))
            { 
                Console.WriteLine($"Error. Expected a valid real number, got '{input}' instead"); 
            }
            else
                return value;
        }
    }

    static void SolveQuadraticInteractive()
    {
        double a, b, c;
        a = ReadDouble("a");
        b = ReadDouble("b");
        c = ReadDouble("c");
        (double? root1, double? root2) = SolveQuadratic(a, b, c);
        int rootsAmount;
        if (root1 == null)
            rootsAmount = 0;
        else if (root1 != null && root2 == null)
            rootsAmount = 1;
        else
            rootsAmount = 2;
        Console.WriteLine($"Equation is: ({a}) x^2 + ({b}) x + ({c}) = 0");
        Console.WriteLine($"There are {rootsAmount} roots");
        if (rootsAmount == 1)
            Console.WriteLine($"x1 = {root1}");
        else if (rootsAmount == 2)
        {
            Console.WriteLine($"x1 = {root1}\nx2 = {root2}");
        }
    }
}