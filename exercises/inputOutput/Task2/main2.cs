using System;
using static System.Console;

public static class Program
{
	public static void Main(string[] args)
	{
		char[] splitDelimiters =  {' ','\t', '\n'};
		var splitOptions = StringSplitOptions.RemoveEmptyEntries;

		for (string line = ReadLine(); line != null; line = ReadLine())
		{
			var numbers = line.Split(splitDelimiters,splitOptions);
			foreach (var number in numbers)
			{
				double x = double.Parse(number);
				Error.WriteLine($"{x} {Math.Sin(x)} {Math.Cos(x)}");
			}		

		}

	}
}
