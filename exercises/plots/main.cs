using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{

	static void Main(){

		// Data is taken from the Wikipidea table

		char[] split_delimiters = {' ','\t','\n'}; // Splitting data
		var split_options = StringSplitOptions.RemoveEmptyEntries;

		vector x = new vector(32);  // x values
		vector y1 = new vector(32); // erf(x)
		vector y2 = new vector(32); // 1 - erf(x)

		int s = 0;
		for( string line = ReadLine(); line != null; line = ReadLine() ){

			var numbers = line.Split(split_delimiters,split_options);
			x[s] = double.Parse(numbers[0]);
			y1[s] = double.Parse(numbers[1]);
			y2[s] = double.Parse(numbers[2]);
			s += 1;
        	}

		// Taking data from Wiki-table

		double erf;

		for(int i = 0; i< 32;i++){

			erf = sfun.erf(x[i]);

			WriteLine($"{x[i]} {y1[i]} {erf}");

		}
		WriteLine(); WriteLine();

		double gamma;
		double lngamma;

		double x1; 
		int N = 100;

		int a = 1; 
		int b = 10; 

		for(int i = 0; i < N; i++){

			x1 = a + (b-a)*i/(N-1);

			gamma = sfun.gamma(x1);
			lngamma = sfun.lngamma(x1);
			
			WriteLine($"{x1} {gamma} {lngamma}");

		}
		WriteLine(); WriteLine();

		var fact = new double[b];  
		var lnfact = new double[b];

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
