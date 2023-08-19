using System;
using static System.Console;
using static System.Math;

public class minimization{
		
		public static vector gradient(Func<vector,double> f, vector x){
			//eq 3...
			int n = x.size;
			vector grad = new vector(n); //The gradient is a vector
			double fx = f(x);
			double epsillon = Pow(2,-26);
			for(int i=0; i<n; i++){
				double dx = Abs(x[i])*epsillon;
				if(Abs(x[i]) < Sqrt(epsillon)){
					dx = epsillon;
				}
				x[i] += dx;
				grad[i] = (f(x)-fx)/dx;
				x[i] -= dx;
			}
			return grad;
		}//gradient


		public static vector  qnewton(Func<vector,double> f, vector xstart, double acc){
			vector x = xstart.copy();
			int n = x.size;
			int step = 0; //max step is 10000
			double epsillon = Pow(2,-26);
			vector grad = gradient(f, x);
			double fx = f(x);
			matrix B = new matrix(n,n); //...one typically uses the inverse Hessian matrix denoted B...
			B.set_unity();
			
			while(acc < grad.norm() && step < 10000){
				step++;
				vector dx = -B*grad; //eq 6 ∆x = −H(x)−1∇φ(x) 
				
			if(dx.norm() < epsillon*x.norm() || dx.norm() < acc){//Unsuccesful step...
					Error.WriteLine("dx < deltax");
					//break;
				}
				vector z; //z=x+s
				double fz, lambda = 1.0;
				while(true){
					z = x+dx*lambda; //z=x+s
					fz = f(z);
					if(fz < fx){break;}
					if(lambda < epsillon){
						B.set_unity();//resetting B - bottom page 2
						break;
					}
					lambda /= 2;
				}//while
			vector s = z-x;
			vector gradz = gradient(f, z);
			vector y = gradz-grad; //below eq 12 y=∇φ(x+s)−∇φ(x)
			vector u = s - B*y; //below eq 12 u=s−By
			double u_trans_y = u.dot(y); //for eq 18
			if(Abs(u_trans_y) > 1e-6){
				B.update(u,u,1/u_trans_y); //only performs the update if denominator is not too small, that is, |uTy| > ε
			} else {B.set_unity();}
			x = z;
			grad = gradz;
			fx = fz;
			}//while
		return x;

		}//qnewton



}//class
