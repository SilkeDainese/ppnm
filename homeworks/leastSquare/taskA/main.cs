using System;
using static System.Console;
using static System.Math;

public class RadioactiveDecayFit {

    public static void Main() {
        // Tabulated data for radioactive decay fit.
        double[] timeData = new double[] {1, 2, 3, 4, 6, 9, 10, 13, 15}; // time [days]
        double[] activityData = new double[] {117, 100, 88, 72, 53, 29.5, 25.2, 15.2, 11.1}; // Activity
        double[] uncertaintyData = new double[] {5, 5, 5, 4, 4, 3, 3, 2, 2};

        // Fit functions (constant and linear term).
        var fitFunctions = new Func<double, double>[] { z => 1.0, z => z };

        for (int i = 0; i < timeData.Length; i++) {
            WriteLine($"{timeData[i]} {activityData[i]} {uncertaintyData[i]}");
        }

        WriteLine("\n");

        for (int i = 0; i < activityData.Length; i++) {
            uncertaintyData[i] = uncertaintyData[i] / activityData[i];
            activityData[i] = Log(activityData[i]);
        }

        // Fitting:
        double[] coefficients = lsfit.fit(timeData, activityData, uncertaintyData, fitFunctions);

        for (double t = 0; t < 16; t += 1.0 / 32) {
            double result = 0;
            for (int j = 0; j < fitFunctions.Length; j++) {
                result += coefficients[j] * fitFunctions[j](t);
            }
            WriteLine($"{t} {Exp(result)}");
        }

        // Saving the fit information in a separate file.
        using (var outfile = new System.IO.StreamWriter("fitlog.txt")) {
            outfile.WriteLine("\n");
            outfile.WriteLine($"Fit parameters: a = {coefficients[0]}, lambda = {coefficients[1]}");
            outfile.WriteLine($"The half-life is found by Ln(2)/lambda and is {Log(2) / (-coefficients[1])} days");
            outfile.WriteLine("This agrees relatively well with the modern data table value of 3.63 days (wiki)");
        }
    }
}
