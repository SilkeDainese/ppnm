using System;
using static System.Console;
using static System.Math;

public class main{

	public static void Main(){
		//Data:
		double[] ts = new double[] {1,  2,  3, 4, 6, 9,   10,  13,  15}; // time [days]
		double[] ys = new double[] {117,100,88,72,53,29.5,25.2,15.2,11.1}; // Activity
		double[] dys = new double[] {5,5,5,4,4,3,3,2,2};
		//Fit function(canstant and linear term):
		var funcs = new Func<double,double>[] { z => 1.0, z => z};
		
		for(int i=0; i<ts.Length; i++){ //Data writen to a list
			WriteLine($"{ts[i]} {ys[i]} {dys[i]}");
		}
		
		WriteLine($"\n");
		
		for(int i=0; i<ys.Length; i++){ //Adjusting data for fit
			dys[i] = dys[i]/ys[i];
			ys[i] = Log(ys[i]);
		}
		
		//Fitting:
		double[] cs = lsfit.fit(ts, ys, dys, funcs);
		
		for(double t=0; t<16; t+=1.0/32){ //Makes function from cs
			double res = 0;
			for(int j=0; j<funcs.Length; j++){
				res += cs[j]*funcs[j](t);
			}
			WriteLine($"{t} {Exp(res)}"); //exp since the fit is made in linear form
		}
		
		//Saving the fit information in its own file
		using(var outfile = new System.IO.StreamWriter("out.txt")){
			outfile.WriteLine("part b:");
			outfile.WriteLine("\n");
			outfile.WriteLine("Covariance Matrix");
			outfile.WriteLine($"{conv}")
			outfile.WriteLine($"Fitted half-life is found by Ln(2)/lambda and is {Log(2)/(-cs[1])} days");
			outfile.WriteLine("So this is not within the modern dat errorbar value");
		}
	}


}
