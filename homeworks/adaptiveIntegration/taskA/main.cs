using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){
		WriteLine($"Test of integration:");
		double a = 0.0;
		double b = 1.0;
		
		Func<double,double> f1 = x => Sqrt(x);
		double result1 = integration.integrate(f1, a, b);
		WriteLine($"Integral of the square root of x from 0 to 1 = {result1}, expected: 0.6667");
	
		Func<double,double> f2 = x => 1.0/Sqrt(x);
		double result2 = integration.integrate(f2, a, b);
		WriteLine($"Integral of 1 divided by the square root of x from 0 to 1 = {result2}, expected: 2");
		
		Func<double,double> f3 = x => 4.0*Sqrt(1.0-Pow(x,2));
		double result3 = integration.integrate(f3, a, b);
		WriteLine($"Integral of 4 times the square root of 1 minus x squared from 0 to 1 = {result3}, expected: 3.14");

		Func<double,double> f4 = x => Log(x)/Sqrt(x);
		double result4 = integration.integrate(f4, a, b);
		WriteLine($"Integral of the natural logarithm of x divided by the square root of x from 0 to 1 = {result4}, expected: -4");
	
	}//Main

}//class
