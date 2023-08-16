using System;
using static System.Math;

public class qspline{
	private double[] x, y, b, c;

	public static int binsearch(double[] x, double z){
		int i=0, j=x.Length-1;
		while(j-i>1){
			int mid=(i+j)/2;
			if(z>x[mid]) i=mid; else j=mid;
		}
		return i;
	}

	public qspline(double[] xs, double[] ys){
		int n = xs.Length;
		x = new double[n];
		y = new double[n];
		b = new double[n-1];
		c = new double[n-1];
		for(int i=0; i<n; i++){ //Fill arrays
			x[i]=xs[i];
			y[i]=ys[i];
		} 
		double[] p = new double[n-1];
		double[] h = new double[n-1];
		for(int i=0; i<n-1; i++){ //recusively constants
			h[i] = x[i+1]-x[i];
			p[i] = (y[i+1]-y[i])/h[i];
		}
		c[0]=0; 
		for(int i=0; i<n-2; i++){ //recursion up
			c[i+1] = (p[i+1]-p[i]-c[i]*h[i])/h[i+1];
		}
		c[n-2]=c[n-2]/2;
		for(int i=0; i<n-3; i++){ //recursion down
			c[i] = (p[i+1]-p[i]-c[i+1]*h[i+1])/h[i];
		}
		for(int i=0; i<n-1; i++){ 
			b[i] = p[i]-c[i]*h[i];
		}
	}

	public double qspline_eval(double z){
		int id = binsearch(x, z);
		double h = z-x[id];
		return y[id]+h*(b[id]+h*c[id]);
	}

	public double deriv(double z){
		int id = binsearch(x, z);
		double h = z-x[id];
		return b[id]+2*c[id]*h;
	}
	
	public double integ(double z, double cst){
		double sum = 0;
		int id = binsearch(x, z);
		for(int i=0; i<id; i++){
			double a = (y[i+1]-y[i])/(x[i+1]-x[i]); //slope
			sum += y[i]*(x[i+1] - x[i]) + a*(x[i+1] - x[i])*(x[i+1] - x[i]) / 2;
		}
		double pa = (y[id+1]-y[id])/(x[id+1]-x[id]);
		sum += y[id]*(z - x[id]) + pa*(z - x[id])*(z - x[id]) / 2 + cst;
		return sum;
	}
	
	

}
