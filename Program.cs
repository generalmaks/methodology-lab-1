using System.Numerics;

(T?, T?) SolveQuadratic<T>(T a, T b, T c) where T: INumber<T>, IRootFunctions<T>
{
    try
    {
        (T?, T?) answer = (default, default);
        T two = T.CreateChecked(2);
        T four = T.CreateChecked(4);
        T D = b * b - four * a * c;
        if (D == T.Zero)
        {
            answer = (-b / (two * a), default);
        }
        if (D > T.Zero)
        {
            var root1 = (-b + T.Sqrt(D)) / (two * a);
            var root2 = (-b - T.Sqrt(D)) / (two * a);
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

var quadraticRoots = SolveQuadratic(3.0, -5.0, 2.0);
Console.WriteLine(quadraticRoots);