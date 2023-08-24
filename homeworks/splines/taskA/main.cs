using static System.Console;
using static System.Math;
using static linspline;

public class main{

    public static void Main() {
        // Tabulated values [x, y] for testing interpolation using a sinus function.
        double[] xValues = new double[] {0, 0.5, 1.0, 1.5, 2.0, 2.5, 3.0, 3.5, 4.0, 4.5, 5.0, 5.5, 6.0};
        double[] yValues = new double[13];
        for (int i = 0; i < xValues.Length; i++) {
            yValues[i] = Sin(xValues[i]);
        }
        for (int i = 0; i < xValues.Length; i++) {
            WriteLine($"{xValues[i]} {yValues[i]}");
        }
	WriteLine("\n");        
        linspline spline = new linspline(xValues, yValues);
        for (double z = 0; z <= 6; z += 1.0 / 16) {
            WriteLine($"{z} {spline.linterp(z)} {spline.linterpInt(z, -1)}");
        }
    }
}






