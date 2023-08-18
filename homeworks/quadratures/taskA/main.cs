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
		WriteLine($"Integration of sqrt(x) from 0 to 1 = {result1}, should be 0.6667");
	
		Func<double,double> f2 = x => 1.0/Sqrt(x);
		double result2 = integration.integrate(f2, a, b);
		WriteLine($"Integration of 1/sqrt(x) from 0 to 1 = {result2}, should be 2");
		
		Func<double,double> f3 = x => 4.0*Sqrt(1.0-Pow(x,2));
		double result3 = integration.integrate(f3, a, b);
		WriteLine($"Integration of 4*sqrt(1-x^2) from 0 to 1 = {result3}, should be 3.14");

		Func<double,double> f4 = x => Log(x)/Sqrt(x);
		double result4 = integration.integrate(f4, a, b);
		WriteLine($"Integration of ln(x)/sqrt(x) from 0 to 1 = {result4}, should be -4");

	
	}//Main

}//class
