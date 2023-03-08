using System;
using static System.Math;
using static System.Console;

public static class sfunc{
	public static double gamma(double x){
		if (x<0) return PI/Sin(PI*x)/gamma(1-x);
		if (x<9) return gamma(x+1)/x;
		double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
		return Exp(lngamma);
	}
	

	public static double lngamma(double x){
		if(x<0){
			Console.WriteLine("Cannot do lngamma for negative numbers");
			return -1;
		}
		
		if(x<9) return Log(gamma(x));

		double lngammaS = x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
		return lngammaS;
	}

}


