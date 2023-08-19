using System;
using static System.Console;
using static System.Math;

public class ann{
	public int n; //number of hidden neurons
	public Func<double,double> f; //activation function
	public Func<double,double> f_diff;
	public Func<double,double> f_int;
	public vector p; //network parameters

	public ann(int n, Func<double,double> f, Func<double,double> f_diff, Func<double,double> f_int){ //constructor
		this.n = n;
		this.f = f;
		this.f_diff = f_diff;
		this.f_int = f_int;
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
	
	public double response_diff(double x){
		double Fp_diff = 0;
		for(int i=0; i<n; i++){
			double a = p[3*i+0];
			double b = p[3*i+1];
			double w = p[3*i+2];
			Fp_diff += f_diff((x-a)/b)*w/b;
		}
		return Fp_diff;
	}//response_diff

	public double response_int(double x){
		double Fp_int = 0;
		for(int i=0; i<n; i++){
			double a = p[3*i+0];
			double b = p[3*i+1];
			double w = p[3*i+2];
			Fp_int += f_int((x-a)/b)*w*b;
		}
		return Fp_int;
	}//response_int


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
