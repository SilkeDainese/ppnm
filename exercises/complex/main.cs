using System;
using static System.Console;
using static System.Math;

class main{
	static void Main(){
		complex min1 = new complex(-1,0);
		WriteLine($"sqrt(-1) = {cmath.sqrt(min1)}");
		WriteLine("Calculated manially it is: i");
		WriteLine($"sqrt(i) = {cmath.sqrt(cmath.I)}");
                WriteLine("Calculated manially it is: 0.707 + 0.707i");
		WriteLine($"e^i = {cmath.exp(cmath.I)}");
                WriteLine("Calculated manially it is: 0.54+0.84i");
		WriteLine($"e^i*pi = {cmath.exp(cmath.I*PI)}");
                WriteLine("Calculated manially it is: -1");
		WriteLine($"i^i = {cmath.pow(cmath.I, cmath.I)}");
                WriteLine("Calculated manially it is: 0.208");
		WriteLine($"ln(i) = {cmath.log(cmath.I)}");
                WriteLine("Calculated manially it is: 1.57i");
		WriteLine($"sin(i*pi) = {cmath.sin(cmath.I*PI)}");
                WriteLine("Calculated manially it is: 11.55i");
	}
}
