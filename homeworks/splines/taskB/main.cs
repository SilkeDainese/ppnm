using System;
using static System.Console;
using static System.Math;
using static qspline;

public class main{
	public static void Main(){
		//Tabulated values to test qspline after.
		double[] xs = new double[] {-7,-6,-5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5,6,7};
		double[] y1 = new double[xs.Length];
		double[] y2 = new double[xs.Length];
		double[] y3 = new double[xs.Length];
		for(int i=0; i<xs.Length; i++){ //Findes the y-values.
			y1[i] = 1;
			y2[i] = xs[i];
			y3[i] = Pow(xs[i],2);
		}
		
		qspline s1 = new qspline(xs, y1);
		for(int i=0; i<xs.Length; i++){ //Writes the tabulatede vaules in a tabel.
			WriteLine($"{xs[i]} {y1[i]}");
		}
		WriteLine($"\n");
		for(double z=-7; z<=7; z+=1.0/32){
			double inter = s1.qspline_eval(z);
			double integ = s1.integ(z,-4);
			double deriv = s1.deriv(z);
			WriteLine($"{z} {inter} {integ} {deriv}");
		}
		
		WriteLine($"\n");

		qspline s2 = new qspline(xs, y2);
		for(int i=0; i<xs.Length; i++){
			WriteLine($"{xs[i]} {y2[i]}");
		}
		WriteLine($"\n");
		for(double z=-7; z<=7; z+=1.0/32){
			double inter = s2.qspline_eval(z);
			double integ = s2.integ(z,6.5);
			double deriv = s2.deriv(z);
			WriteLine($"{z} {inter} {integ} {deriv}");
		}
	
		WriteLine($"\n");
		qspline s3 = new qspline(xs, y3);
		for(int i=0; i<xs.Length; i++){
			WriteLine($"{xs[i]} {y3[i]}");
		}
		WriteLine($"\n");
		for(double z=-5; z<=5; z+=1.0/32){
			double inter = s3.qspline_eval(z);
			double integ = s3.integ(z,-30);
			double deriv = s3.deriv(z);
			WriteLine($"{z} {inter} {integ} {deriv}");
		}


	}




}
