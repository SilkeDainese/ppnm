using System;
using static System.Console;
using static System.Math;


class main{
	static Func<double,vector,vector> F = delegate(double x, vector y){
		return new vector (y[1],-y[0]);
	};//function

	public static void Main(){
		double a = 0, b = 4*PI;
		vector ya = new vector (0.0,1.0);
		var (xs, ys) = ode.driver(F, a, ya, b);
	
		for(int i = 0;i<xs.size;i++)
			WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
	}//Main()

}//class main
