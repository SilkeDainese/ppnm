using System;
using static System.Console;
using static System.Math;
class main{

	static Func<double,vector,vector> F = delegate(double x, vector y){
		double a = 1.5; double b = 1.0; double c = 3.0; double d = 1.0;
		var xn = y[0];
		var yn = y[1];
		return new vector (a*xn-b*xn*yn, -c*yn+d*xn*yn);
	};//function
	  
	public static void Main(){
		double a = 0, b = 15;
		vector ya = new vector (10.0,5.0);
		var xs = new genlist<double>();
		var ys = new genlist<vector>();
		var y_end = ode.driver(F, a, ya, b, xs, ys);
		WriteLine("Test of yend is returned");
		y_end.print("y end = ");
		for(int i = 0;i<xs.size;i++)
			WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
	} //Main()	
}//class main
