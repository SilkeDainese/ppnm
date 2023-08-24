using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){
		WriteLine($"Integration tests comparing with different methods from A and B:/n");
		double a = 0.0, b = 1.0;
		
		int i = 0, j = 0, k = 0, l = 0; //To record the number of integrand evaluations
		
		Func<double,double> f1 = x => {i++; return 1/Sqrt(x);};
		Func<double,double> f2 = x => {j++; return 1/Sqrt(x);};
		double result1 = integration.integrate(f1, a, b);
		double result2 = integration.vt_integrate(f2, a, b);
		WriteLine($"Integration of 1/sqrt(x) from 0 to 1 = {result1} and took {i} iterations - part A");
		WriteLine($"Integration of 1/sqrt(x) from 0 to 1 = {result2} and took {j} iterations - part B");

		Func<double,double> f3 = x => {k++; return Log(x)/Sqrt(x);};
		Func<double,double> f4 = x => {l++; return Log(x)/Sqrt(x);};
		double result3 = integration.integrate(f3, a, b);
		double result4 = integration.vt_integrate(f4, a, b);
		WriteLine($"Integration of ln(x)/sqrt(x) from 0 to 1 = {result3} and took {k} iterations - part A");
		WriteLine($"Integration of ln(x)/sqrt(x) from 0 to 1 = {result4} and took {l} iterations - part B");

		WriteLine($"Python scipy comparison:");
		var instream =new System.IO.StreamReader("python_result.txt");
		for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
		WriteLine(line);
        }


	}//Main
	
}//class
