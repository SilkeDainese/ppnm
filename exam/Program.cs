using System;
using static System.Math;
using static System.Console;
using static System.Random;
using System.IO;

public class Program {

    static void Main(string[] args)
    {

        var random = new Random();
        var dataSize = random.Next(10,50);
        var xsData = new double[dataSize];
        var ysData = new double[dataSize];

        //using (StreamWriter writer = new StreamWriter("testpoints.data", true))
	using (StreamWriter writer = new StreamWriter("testpoints.data"))

		{
		for (int i = 0; i < dataSize; i++)
		{
			xsData[i] = random.NextDouble();
			ysData[i] = random.NextDouble();
		}
		Array.Sort(xsData,ysData);
		for (int i = 0; i < dataSize; i++)
                {
			writer.WriteLine($"{xsData[i]} {ysData[i]}");
		}
        } //using

        var amkima = new Akima(xsData, ysData, 1000);
        amkima.Interpolation();
        var dto = amkima.Evaluate();

        using (StreamWriter writer = new StreamWriter("interpolated.data"))
        {
            for (int i = 0; i < dto.Xvalues.Count;  i++)
            {
                writer.WriteLine($"{dto.Xvalues[i]} {dto.Yvalues[i]}");
            }
	
        }

	// Define for comparing cubic and Akima splines
	double[] compareX = {-5,-4,-3,-2,-1,0,1,2,3,4,5};
	double[] compareY = {0 , 4, 3, 5,10,2,9,1,6,3,0};
	int n = compareX.Length;
	using (StreamWriter writer = new StreamWriter("points.data"))
	{
		for (int i = 0; i < n;  i++)
		{
		writer.WriteLine($"{compareX[i]} {compareY[i]}");
		}
	}

	var akimacomp  = new Akima(compareX, compareY, 1000);
	akimacomp.Interpolation();
	var dtos = akimacomp.Evaluate();
	using (StreamWriter writer = new StreamWriter("Akimacompare.data"))
	{
		for (int i = 0; i < dto.Xvalues.Count;  i++)
		{
			writer.WriteLine($"{dtos.Xvalues[i]} {dtos.Yvalues[i]}");
		}
        }
	
	double[] b = new double[n];
	double[] c = new double[n - 1];
	double[] d = new double[n - 1];
	double[] A = new double[n];
	double[] D = new double[n];
	double[] Q = new double[n];
	double[] B = new double[n];

	CubeSpline.cspline_build(compareX,compareY, b, c, d, A, D, Q, B);
	double minX = compareX[0];
	double maxX = compareX[n - 1];
	double step = 1.0 / 1000;
	using (StreamWriter writer = new StreamWriter("Cubic.data"))
	{
		for(double i = minX+step; i<maxX; i+=step)
		{
			double interpolatedValue = CubeSpline.cspline_evaluate(compareX,compareY, b, c, d, i);
	 		double slope = CubeSpline.cspline_diff(compareX, compareY, b, c, d, i);    				            	
			WriteLine("{0} {1} {2}", i, interpolatedValue, slope);
		}
       	
        }
}
}
