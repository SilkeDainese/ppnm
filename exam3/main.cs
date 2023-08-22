using System;
using static System.Math;
using static System.Console;
using static System.Random;
using System.IO;

public class main{
	public static void Main(){
		var random = new Random();
        	int dataSize=random.Next(10, 50);
		double[] xsData = new double[dataSize];
		double[] ysData = new double[dataSize];
		for (int i = 0; i<dataSize; i++)
		{
			xsData[i] = random.NextDouble();
			ysData[i] = random.NextDouble();
			using (StreamWriter writer = new StreamWriter("testpoints.data", true))
			{
			writer.WriteLine($"{xsData[i]} {ysData[i]}");
                        }
		}

		double[] xsInterpolated, ysInterpolated;
		Akima.Interpolation(xsData, ysData, out xsInterpolated, out ysInterpolated);
				                
		for(int i = 0; i < xsInterpolated.Length; i++){
	        // Write to the file called interpolated.data
			using (StreamWriter writer = new StreamWriter("interpolated.data", true))
			{
				writer.WriteLine($"{xsInterpolated[i]} {ysInterpolated[i]}");
			}
		}
	}
	

}
