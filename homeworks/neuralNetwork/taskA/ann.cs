using System;
using static System.Console;
using static System.Math;

public class ann{
	public int n; //number of hidden neurons
	public Func<double,double> f; //activation function
	public vector p; //network parameters

	public ann(int n, Func<double,double> f){ //constructor
		this.n = n;
		this.f = f;
		this.p = new vector(3*n);
	}//ann
	
	public double response(double x){
		//return the response of the network to the input signal x
		double Fp = 0;
		//Fp(x) = ∑i f((x-ai)/bi)*wi
		for(int i=0; i<n; i++){
			double a = p[3*i+0];
			double b = p[3*i+1];
			double w = p[3*i+2];
			Fp += f((x-a)/b)*w;
		}
		return Fp;
	}//response
	
	public void train(vector x, vector y){
		//Cost function: C(p) = ∑k=1..N (Fp(xk) - yk)²
		Func<vector,double> cost_function  = C => {
			p = C;
			double s = 0;
			for(int i=0; i<x.size; i++){
				s += Pow(response(x[i])-y[i],2);
			}
			return s/x.size;
		}; //Func
		vector v = p;
		vector result = minimization.qnewton(cost_function, v, 1e-3);
		p = result;
	}//train
	
	

}//class
