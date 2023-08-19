using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){
		Func<double,double> gw = x => x*Exp(-x*x); //Gaussian wavelet
		Func<double,double> g = x => Cos(5*x-1)*Exp(-x*x); //test function
		int n = 5; //Hidden neurons
		ann network = new ann(n, gw);//constructing the network
		double a = -1, b = 1; //interval
		int m = 20; //number of points
		vector xs = new vector(m);
		vector ys = new vector(m);
		for(int i=0; i<xs.size; i++){ //making x- and y-points
			xs[i] = a+(b-a)*i/(m-1);
			ys[i] = g(xs[i]);
			WriteLine($"{xs[i]} {ys[i]}");
		}
		WriteLine("\n");
		for(int i=0; i<network.n; i++){
			network.p[3*i+0] = a+(b-a)*i/(network.n-1);
			network.p[3*i+1] = 1;
			network.p[3*i+2] = 1;
		}
		network.train(xs, ys);
		for(double z=a; z<b; z+=1.0/64){
			WriteLine($"{z} {network.response(z)}");
		}
	}//Main
	

}//class
