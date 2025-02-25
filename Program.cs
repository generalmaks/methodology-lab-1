(double?, double?) SolveQuadratic(double a, double b, double c)
{
    try
    {
        (double?, double?) answer = (null, null);
        double D = b * b - 4 * a * c;
        if (D == 0)
        {
            answer = (-b / (2 * a), null);
        }
        if (D > 0)
        {
            var root1 = (-b + Math.Sqrt(D)) / (2 * a);
            var root2 = (-b - Math.Sqrt(D)) / (2 * a);
            answer = (root1, root2);
        }
        return answer;
    }
    catch (Exception e)
    {
        Console.WriteLine("Error occured while trying to solve quadratic equation: " + e);
        throw;
    }
}

var quadraticRoots = SolveQuadratic(4, -5, -12);
Console.WriteLine(quadraticRoots);