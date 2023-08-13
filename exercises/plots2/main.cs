using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{

	static void Main(){

		// Data taken from Wikipedia tabæe

		char[] split_delimiters = {'\t','\n',' '};
		var split_options = StringSplitOptions.RemoveEmptyEntries;

		vector x = new vector(32); // x-values
		vector y = new vector(32); // erf(x)
		vector z = new vector(32); // 1 - erf(x)

		int n = 0;
		for( string line = ReadLine(); line != null; line = ReadLine() ){

			var numbers = line.Split(split_delimiters,split_options);
			x[n] = double.Parse(numbers[0]);
			y[n] = double.Parse(numbers[1]);
			z[n] = double.Parse(numbers[2]);
			n += 1;
        	}

		// Taking data from Wiki-table

		double erf;

		for(int i = 0; i< 32;i++){

			erf = sfun.erf(x[i]);
			WriteLine($"{x[i]} {y[i]} {erf}");

		}
		WriteLine();

		double gamma;
		double lngamma;

		double xs; // x value itteration
		int N = 100; // number of points in interval

		int a = 1; // start of interval
		int b = 10; // end of interval

		for(int i = 0; i < N; i++){

			xs = a + (b-a)*i/(N-1);

			gamma = sfun.gamma(xs);
			lngamma = sfun.lngamma(xs);
			

			WriteLine($"{xs} {gamma} {lngamma}");

		}
		WriteLine();

		var fact   = new double[b]; // factorial 
		var lnfact = new double[b]; // logarithm of factorial

		for(int i = 0; i < b; i++){		
			fact[i] = 1;
			for(int j = 1; j <= i+1; j++){

				fact[i] *= j;

			}
			lnfact[i] = Log(fact[i]); // logarithm

			WriteLine($"{i+1} {fact[i]} {lnfact[i]}");

		}



}//Main

}//main
