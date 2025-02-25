using System;
namespace lab1;
class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 3)
        {
            if (double.TryParse(args[0], out double a) &&
                double.TryParse(args[1], out double b) &&
                double.TryParse(args[2], out double c))
            {
                SolveQuadratic(a, b, c);
            }
        }
        else if (args.Length == 0)
        {
            SolveQuadraticInteractive();
        }
        else
        {
            Console.WriteLine("Incorrect number of arguments");
        }
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
                double root1 = (-b + Math.Sqrt(D)) / (2 * a);
                double root2 = (-b - Math.Sqrt(D)) / (2 * a);
                answer = (root1, root2);
            }

            int rootsAmount = answer switch
            {
                (null, null) => 0,
                (_, null) => 1,
                _ => 2
            };


            Console.WriteLine($"Equation is: ({a}) x^2 + ({b}) x + ({c}) = 0");
            Console.WriteLine($"There are {rootsAmount} roots");
            if (rootsAmount == 1)
                Console.WriteLine($"x1 = {answer.Item1}");
            else if (rootsAmount == 2)
            {
                Console.WriteLine($"x1 = {answer.Item1}\nx2 = {answer.Item2}");
            }

            return answer;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occurred while trying to solve quadratic equation: " + e);
            throw;
        }

    }

    private static (double?, double?) SolveQuadratic(double[] arr)
    {
        double a, b, c;
        a = arr[0];
        b = arr[1];
        c = arr[2];
        return SolveQuadratic(a, b, c);
    }

    static double ReadDouble(string variable)
    {
        while (true)
        {
            string? input;
            Console.Write($"{variable} = ");
            input = Console.ReadLine();
            if (!double.TryParse(input, out double value))
                Console.WriteLine($"Error. Expected a valid real number, got '{input}' instead");
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
    }
}