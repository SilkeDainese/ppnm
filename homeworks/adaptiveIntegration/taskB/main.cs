using System;
using static System.Console;
using static System.Math;

public class main{
    public static void Main() {
        WriteLine($"Integration Test with Different Methods:");
        double lowerBound = 0.0, upperBound = 1.0;
        
        int counterA1 = 0, counterB1 = 0, counterA2 = 0, counterB2 = 0; // To track integrand evaluations
        
        Func<double, double> func1 = x => { counterA1++; return 1 / Sqrt(x); };
        Func<double, double> func2 = x => { counterB1++; return 1 / Sqrt(x); };
        double resultA1 = integration.integrate(func1, lowerBound, upperBound);
        double resultB1 = integration.vartran_integrate(func2, lowerBound, upperBound);
        WriteLine($"Integral of 1/sqrt(x) from 0 to 1 = {resultA1} using {counterA1} evaluations - Method A");
        WriteLine($"Integral of 1/sqrt(x) from 0 to 1 = {resultB1} using {counterB1} evaluations - Method B");

        Func<double, double> func3 = x => { counterA2++; return Log(x) / Sqrt(x); };
        Func<double, double> func4 = x => { counterB2++; return Log(x) / Sqrt(x); };
        double resultA2 = integration.integrate(func3, lowerBound, upperBound);
        double resultB2 = integration.vartran_integrate(func4, lowerBound, upperBound);
        WriteLine($"Integral of ln(x)/sqrt(x) from 0 to 1 = {resultA2} using {counterA2} evaluations - Method A");
        WriteLine($"Integral of ln(x)/sqrt(x) from 0 to 1 = {resultB2} using {counterB2} evaluations - Method B");

        WriteLine($"Comparison with Python SciPy results:");
        var inputStream = new System.IO.StreamReader("python_result.txt");
        for (string line = inputStream.ReadLine(); line != null; line = inputStream.ReadLine()) {
            WriteLine(line);
        }
    }
}

