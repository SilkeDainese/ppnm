using System;
using static System.Console;
using static System.Math;
using static qspline;

public class main {

    public static void Main() {
        // Tabulated values for testing Quadratic Spline.
        double[] xValues = new double[] {-9,-8,-7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7,8,9};
        double[] y1Values = new double[xValues.Length];
        double[] y2Values = new double[xValues.Length];
        double[] y3Values = new double[xValues.Length];
        for (int i = 0; i < xValues.Length; i++) {
            y1Values[i] = 1;
            y2Values[i] = xValues[i];
            y3Values[i] = Pow(xValues[i], 2);
        }

        qspline spline1 = new qspline(xValues, y1Values);
        for (int i = 0; i < xValues.Length; i++) {
            WriteLine($"{xValues[i]} {y1Values[i]}");
        }
        WriteLine("\n");
        for (double z = -7; z <= 7; z += 1.0 / 32) {
            double interpolated = spline1.qspline_eval(z);
            double integrated = spline1.integ(z, -4);
            double derivative = spline1.deriv(z);
            WriteLine($"{z} {interpolated} {integrated} {derivative}");
        }

        WriteLine("\n");

        qspline spline2 = new qspline(xValues, y2Values);
        for (int i = 0; i < xValues.Length; i++) {
            WriteLine($"{xValues[i]} {y2Values[i]}");
        }
        WriteLine("\n");
        for (double z = -7; z <= 7; z += 1.0 / 32) {
            double interpolated = spline2.qspline_eval(z);
            double integrated = spline2.integ(z, 6.5);
            double derivative = spline2.deriv(z);
            WriteLine($"{z} {interpolated} {integrated} {derivative}");
        }

        WriteLine("\n");
        qspline spline3 = new qspline(xValues, y3Values);
        for (int i = 0; i < xValues.Length; i++) {
            WriteLine($"{xValues[i]} {y3Values[i]}");
        }
        WriteLine("\n");
        for (double z = -5; z <= 5; z += 1.0 / 32) {
            double interpolated = spline3.qspline_eval(z);
            double integrated = spline3.integ(z, -30);
            double derivative = spline3.deriv(z);
            WriteLine($"{z} {interpolated} {integrated} {derivative}");
        }
    }
}
