using System;
using static System.Console;
using static System.Math;
using static linspline;

public class main{
	public static void Main(){
		// Making values for [x, y] to test linspline. Chosen the sinus-function.
		double[] xs = new double[] {0, 0.5,1.0, 1.5,2.0, 2.5, 3.0, 3.5, 4.0, 4.5, 5.0, 5.5, 6.0};
		double[] ys = new double[13];
		for(int i=0; i<xs.Length; i++){ //Findes the y-values for a sinus-function.
			ys[i] = Sin(xs[i]);
		}
		for(int i=0; i<xs.Length; i++){ //Writes the tabulatede vaules in a tabel.
			WriteLine($"{xs[i]} {ys[i]}");
		}
		
		WriteLine($"\n");

		
		linspline s = new linspline(xs, ys);
		for(double z=0; z<=6; z+=1.0/16){
			WriteLine($"{z} {s.linterp(z)} {s.linterpInt(z, -1)}");
		}
		
		
	}




}
