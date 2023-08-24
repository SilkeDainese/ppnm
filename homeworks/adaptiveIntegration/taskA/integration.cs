using System;
using static System.Console;
using static System.Math;
using static System.Double;

public static partial class integration{
	
	public static double integrate(Func<double,double> f,
		double a, double b,
		double delta=0.001, double epsilon=0.001,
		double f2=NaN, double f3=NaN){
		
		double h = b-a;
		if(IsNaN(f2)){
			f2 = f(a+2*h/6);
			f3 = f(a+4*h/6);
		}
		double f1 = f(a+h/6);
		double f4 = f(a+5*h/6);
		double Q = (2*f1+f2+f3+2*f4)/6*(b-a);
		double q = (f1+f2+f3+f4)/4*(b-a);
		double err = Abs(Q-q);
		if(err <= Max(delta, epsilon*Abs(Q))){
			return Q;
		} else {
			return integrate(f,a,(a+b)/2,delta/Sqrt(2),epsilon,f1,f2) + 
			integrate(f,(a+b)/2,b,delta/Sqrt(2),epsilon,f3,f4);
		}
	}//integrate


}//class
