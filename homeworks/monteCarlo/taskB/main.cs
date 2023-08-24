using System;
using static System.Console;
using static System.Math;

public class main{
    public static void Main() {
        WriteLine($"Testing Monte Carlo Integration using the plainmc method: \n");
        
        WriteLine($"Integrating a 2-dimensional function: x * y dx dy, with x = [0,1] and y = [0,1]:");
        Func<vector, double> function1 = vec => vec[0] * vec[1];
        vector lowerBound1 = new double[2] { 0, 0 };
        vector upperBound1 = new double[2] { 1, 1 };
        var result1 =mcintegration.plainmc(function1, lowerBound1, upperBound1, 50000);
        WriteLine($"The result is {result1.Item1}, estimated error: {result1.Item2}, actual error: {result1.Item1 - 0.25}.");
        WriteLine($"Expected: 0.25 \n");

        WriteLine($"Integrating a 2-dimensional function: x * sin(y) dx dy, with x = [0,1] and y = [0,pi]:");
        Func<vector, double> function2 = vec => vec[0] * Sin(vec[1]);
        vector lowerBound2 = new double[2] { 0, 0 };
        vector upperBound2 = new double[2] { 1, PI };
        var result2 = mcintegration.plainmc(function2, lowerBound2, upperBound2, 50000);
        WriteLine($"The result is {result2.Item1}, estimated error: {result2.Item2}, actual error: {result2.Item1 - 1.0}.");
        WriteLine($"Expected: 1");

        WriteLine($"\n");

        WriteLine($"Integrating a 3-dimensional function: (1 - cos(x) * cos(y) * cos(z) * pi^3)^-1 dx dy dz, with x = [0,pi], y = [0,pi], and z = [0,pi]:");
        Func<vector, double> function3 = vec => 1 / ((1 - Cos(vec[0]) * Cos(vec[1]) * Cos(vec[2])) * Pow(PI, 3));
        vector lowerBound3 = new double[3] { 0, 0, 0 };
	vector upperBound3 = new double[3] { PI, PI, PI };
        var result3 = mcintegration.plainmc(function3, lowerBound3, upperBound3, 50000);
        WriteLine($"The result is {result3.Item1}, estimated error: {result3.Item2}, actual error: {result3.Item1 - 1.393203929}.");
        WriteLine($"Expected: 1.393203929685676");
    }
}
