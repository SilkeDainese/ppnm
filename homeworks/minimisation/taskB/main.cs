using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

public class main{

	static List<double> Es, sigma, error;

	public static double B_W(double E, double m, double gamma, double A){//Breit-Wigner function
		return A/((E-m)*(E-m)+gamma*gamma/4);
	}//B_W
	
	public static double D(vector x){//Fit function
		double m = x[0];
		double gamma = x[1];
		double A = x[2];
		double res = 0;
		for(int i=0; i<Es.Count; i++){
				double E = Es[i];
				double sig = sigma[i];
				double err = error[i];
				res += ((B_W(E, m, gamma, A)-sig)*(B_W(E, m, gamma, A)-sig))/(err*err);
		}
		return res;
	}//D

	
	public static void Main(){
		WriteLine("The implemented minimization function from part A is used to investigate the Higgs boson");
		WriteLine("The Breit-Wigner function is fitted, by minimizing the fit function");
		
		List<double> data = new List<double>();
		int i = 0;
		var instream = System.Console.In;
	        for(string line=instream.ReadLine();line!=null;line=instream.ReadLine()){
	                string[] words = line.Split(" ");
	                foreach(var word in words){
				double val = double.Parse(word);
				data.Add(val);
				i++;
                	}
        	}
        	instream.Close();

		Es = new List<double>();
	        sigma = new List<double>();
	        error = new List<double>();
		for(i=0; i<data.Count; i++){
			if(i%3 == 0){Es.Add(data[i]);}
			if(i%3 == 1){sigma.Add(data[i]);}
			if(i%3 == 2){error.Add(data[i]);}
		}
		
		vector x0 = new double[3] {120,3,6};
		x0.print("x0=");
		WriteLine($"The initial guess is ({x0[0]}, {x0[1]}, {x0[2]})");
		vector result = minimization.qnewton(D, x0, 1e-3);

		double m = result[0];
		double gamma = result[1];
		double A = result[2];

		WriteLine("From the algoritm:");
		WriteLine($"\n\tMass = {m}\n\tWidth = {gamma}\n\tAmplitude = {A}\n");
		//using(var outfile = new System.IO.StreamWriter("fit.txt")){
			for(double e = 100; e <= 160; e+=1.0/64){
				//outfile.WriteLine($"{e} {B_W(e, m, gamma, A)}");
				Error.WriteLine($"{e} {B_W(e, m, gamma, A)}");
			}
		//}

	}//Main


}//class
