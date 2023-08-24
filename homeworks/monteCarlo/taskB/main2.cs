using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){
		WriteLine($"Testing implementation of Monte Carlo integration plainmc methode:");
		
		WriteLine($"\n");

		WriteLine($"Integration of a 2 dimentional function: x*y dx dy, with x = [0,1] and y=[0,1]:");
		Func<vector,double> f1 = x => x[0]*x[1];
		vector a1 = new double[2] {0,0};
		vector b1 = new double[2] {1,1};
		var result1 = mcintegration.plainmc(f1, a1, b1, 50000);
//		var (Q,err) = mcintegration.plainmc(f1, a1, b1, 50000); //en anden måde at skrive værdierne ud på.
		WriteLine($"The result is {result1.Item1} and the estimated error is {result1.Item2} and the actual error is {result1.Item2-0.25}- part A.");
		var result1H = mcintegration.haltonmc(f1, a1, b1, 50000);
		WriteLine($"The result is {result1H.Item1} and the estimated error is {result1H.Item2} and the actual error is {result1H.Item1-0.25} - part B.");
		WriteLine("Should be 0.25");

		WriteLine("\n");
		
		WriteLine("Integration of a 2 dimentional function: x*sin(y) dx dy, with x = [0,1] and y=[0,pi]:");
		Func<vector,double> f2 = x => x[0]*Sin(x[1]);
		vector a2 = new double[2] {0,0};
		vector b2 = new double[2] {1,PI};
		var result2 = mcintegration.plainmc(f2, a2, b2, 50000);
		var (result2H, err2) = mcintegration.haltonmc(f2, a2, b2, 50000);
		WriteLine($"The result is {result2.Item1} and the estimated error is {result2.Item2} and the actual error is {result2.Item1-1} - part A.");
		WriteLine($"The result is {result2H} and the estimated error is {err2} and the actual error is {result2H-1} - part B.");
		WriteLine($"Should be 1");

		WriteLine($"\n");

		WriteLine($"Integration of a 3 dimentional function: (1-cos(x)*cos(y)*cos(z)*pi^3)^-1 dx dy dz, with x = [0,pi], y=[0,pi] and z=[0,pi]:");
		Func<vector,double> f3 = x => {
			return 1/((1-Cos(x[0])*Cos(x[1])*Cos(x[2]))*Pow(PI,3) );
			};
		vector a3 = new double[3] {0,0,0};
		vector b3 = new double[3] {PI,PI,PI};
		int N=50000;
		var result3 = mcintegration.plainmc(f3, a3, b3, N);
		var (result3H, err3) = mcintegration.haltonmc(f3, a3, b3, N);
		WriteLine($"The result is {result3.Item1} and the estimated error is {result3.Item2} and the actual error is {result3.Item1-1.39320} - part A.");
		WriteLine($"The result is {result3H} and the estimated error is {err3} and the actual error is {result3H-1.39320} - part B.");
		WriteLine($"Should be 1.3932039296856768591842462603255");
	}//Main

}//class
