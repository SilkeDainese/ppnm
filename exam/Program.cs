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
}
}
