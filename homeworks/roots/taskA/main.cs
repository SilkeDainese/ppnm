using System;
using static System.Console;
using static System.Math;

public class main{
    public static void Main() {
        WriteLine("Demonstrating Newton's method with numerical Jacobian and back-tracking linesearch /n");

        WriteLine("Test function f(x) = x^2");
        WriteLine("Finding the extremum of f(x) by searching for the roots of the gradient f'(x) = 2x");
        Func<vector, vector> function1 = x => new vector(2 * x[0]);
       	vector initialGuess1 = new double[1] {0.5};
        vector result1 = roots.newton(function1, initialGuess1);
        WriteLine($"The extremum is found at:");
        result1.print();
        WriteLine("The analytical result is 0");

        WriteLine("\n");

        WriteLine("Test function f(x) = log(x) * x^2");
        WriteLine("Finding the extremum of f(x) by searching for the roots of the gradient f'(x) = x + 2 * x * log(x)");
        Func<vector, vector> function2 = x => new vector(2 * x[0] * Log(x[0]) + x[0]);
        vector initialGuess2 = new double[1] {0.5};
        vector result2 = roots.newton(function2, initialGuess2);
        WriteLine($"The extremum is found at:");
        result2.print();
        WriteLine("The analytical result is 0.6065");

        WriteLine("\n");

        WriteLine("Test function f(x, y)");
        Func<vector, vector> function4 = x => new vector(Pow(x[0] - 5, 2), Pow(x[1] - 5, 2));
        vector initialGuess4 = new double[2] {0.5, 0.5};
        vector result4 = roots.newton(function4, initialGuess4);
        WriteLine($"The extremum is found at:");
        result4.print();
        WriteLine("The analytical result is (5, 5)");

        WriteLine("\n");

        WriteLine("Test function f(x, y) = (1 - x)^2 + 100 * (y - x^2)^2");
        WriteLine("Finding the extremum of f(x) by searching for the roots of the gradient f'(x, y) = (-2 * (1 - x) - 400 * x * (y - x^2), 200 * (y - x^2))");
        Func<vector, vector> function3 = x => new vector(-2 * (1 - x[0]) - 2 * x[0] * 200 * (x[1] - x[0] * x[0]), 200 * (x[1] - x[0] * x[0]));
        vector initialGuess3 = new double[2] {0.5, 0.5};
        vector result3 = roots.newton(function3, initialGuess3);
        WriteLine($"The extremum is found at:");
        result3.print();
        WriteLine("The analytical result is (1, 1)");
    }
}
