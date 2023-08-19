using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){
		
		WriteLine("Test function f(x,y)=(1-x)^2+100*(y-x^2)^2");
		WriteLine("Finding the minimum of the function");
		Func<vector,double> f1 = x => (1 - x[0])*(1 - x[0]) + 100*(x[1] - x[0]*x[0])*(x[1] - x[0]*x[0]);
		vector x01 = new double[2] {0, 0};
		double acc1 = 1e-5;
		vector result1 = minimization.qnewton(f1, x01, acc1);
		WriteLine($"Start guess ({x01[0]},{x01[1]})");
		WriteLine($"The minimum was found at ({result1[0]},{result1[1]})");
		WriteLine($"Here f(x,y) = {f1(result1)}");
		WriteLine("There is one minimum at (1,1), for f(x,y)=0");
		
		WriteLine("\n");
		
		WriteLine("Test function f(x,y)=(x^2+y-11)^2+(x+y^2-7)^2");
		WriteLine("Finding the minimum of the function");
		Func<vector,double> f2 = x => Pow(x[0]*x[0]+x[1]-11,2)+Pow(x[0]+x[1]*x[1]-7,2);
		vector x02 = new double[2] {1, 1};
		vector result2 = minimization.qnewton(f2, x02, acc1);
		WriteLine($"Start guess ({x02[0]},{x02[1]})");
		WriteLine($"The minimum was found at ({result2[0]},{result2[1]})");
		WriteLine($"Here f(x,y) = {f2(result2)}");
		WriteLine("There is one minimum at (3,2), for f(x,y)=0");

	}//Main



}//class
