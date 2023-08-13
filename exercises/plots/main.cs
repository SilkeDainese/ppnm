using System;
using static System.Console;
using static System.Math;
using System.IO;
using System;
using static System.Console;
using static System.Math;
using System.IO;

class main{
		static void Main(){
	        	char[] split_delimiters = {' ','\t','\n'};
			var split_options = StringSplitOptions.RemoveEmptyEntries;
			vector x = new vector(32); // x values
			vector y = new vector(32); // erf(x)
			vector z = new vector(32); // 1 - erf(x)
			
			int n = 0;
			for(string line = ReadLine(); line != null; line = ReadLine() ){
				var numbers = line.Split(split_delimiters,split_options);
				x[n] = double.Parse(numbers[0]);
				y[n] = double.Parse(numbers[1]);
				z[n] = double.Parse(numbers[2]);
				n += 1;
		       	} // for-loop
			double erf;
			for(int i = 0; i< 32;i++){
				erf = sfunc.erf(x[i]);
				WriteLine($"{x[i]} {y[i]} {erf}");
			}
			WriteLine();
			
			double gamma;
			double lngamma;
			
			double xs; 
			int N = 100;
			
			int a = 1; 
			int b = 10;
		
			for(int i = 0; i < N; i++){
				xs = a + (b-a)*i/(N-1);
				
				gamma = sfunc.gamma(xs);
				lngamma = sfunc.lngamma(xs);
				WriteLine($"{xs} {gamma} {lngamma}");
			}
			WriteLine();
			
			var fact = new double[b]; 
			var lnfact = new double[b]; 																for(int i = 0; i < b; i++){
				fact[i] = 1;
				for(int j = 1; j <= i+1; j++){
					fact[i] *= j;
				}
			
				lnfact[i] = Log(fact[i]); 
				WriteLine($"{i+1} {fact[i]} {lnfact[i]}");
			}
		}
}	
