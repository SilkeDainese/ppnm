using System;
using static System.Console;
using static System.Math;
class main{

static Func<double,vector,vector> F = delegate(double x, vector y){
	double b = 0.25; double c = 5.0;
	var theta = y[0];
	var omega = y[1];
	return new vector (omega, -b*omega-c*Math.Sin(theta));
};//function

public static void Main(){
	double a = 0, b = 10;
	vector ya = new vector (PI-1.0,0);
	var (xs, ys) = ode.driver(F, a, ya, b);
	
	for(int i = 0;i<xs.size;i++)
		WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
}//Main()


}//class main
