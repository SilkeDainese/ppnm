using System;
using static System.Console;
using static System.Math;

public static class QRGS{
		// Decompose function
		public static void decompose(matrix matrixA, matrix matrixR){
			int rowCount = matrixR.size1;
			for(int i=0;i<rowCount;i++){
				double aiNorm = matrixA[i].norm();
				matrix.set(matrixR,i,i,aiNorm);
				matrixA[i] = matrixA[i]/matrixR[i,i];
				for(int j=i+1;j<rowCount;j++){
					matrixR[i,j] = matrixA[i].dot(matrixA[j]);
					matrixA[j] = matrixA[j] - matrixA[i]*matrixR[i,j];
				}
			}
			
		}
		// Solve function
		public static vector solve(matrix matrixQ, matrix matrixR, vector vectorb){
			vector x =matrixQ.T*vectorb;
			for(int i=x.size-1;i>=0;i--){
				double sum=0;
				for(int k=i+1;k<x.size;k++) sum = sum + matrixR[i,k]*x[k];
				x[i] = (x[i]-sum)/matrixR[i,i];
			}
			return x;
		}
	}

public class roots{
	public static vector newton(Func<vector,vector> f, vector x0, double epsilon=1e-2){
		for(int i=0; i<x0.size; i++){
			if(x0[i] == 0) {x0[i] = 1e-5;}
		}

		vector x = x0.copy();
		int n = x0.size;
		matrix J = new matrix(n,n); //calculating the Jacobian matrix J
		double delta = 0;
		vector fy = new vector(n);
		vector y = new vector(n);

		bool run1 = true;
		int k = 0;
		while(run1){// && k < 1000){
			vector fx = f(x);
			for(int i=0; i<n; i++){ //calculating Jacobian matrix J
				delta = Abs(x[i])*Pow(2,-26);
				x[i] += delta;

				for(int j=0; j<n; j++){
					J[j,i] = (f(x)[j]-fx[j])/delta;
				}
				x[i] -= delta;
			}

		matrix R = new matrix(n,n);
		matrix Q = J.copy();
		QRGS.decompose(Q,R);
		vector Dx = QRGS.solve(Q,R,-fx); // solving JDx=-fx, newtons step
		
		double lambda = 2.0;

		bool run2 = true; //While(||f(x+lambda*Dx)|| < (1-lambda/2)*||f(x)|| )
		while(run2){
			lambda /= 2; //λ←λ/2
			y = x+lambda*Dx; //x ← x + λ∆x
			fy = f(y);
			if(fy.norm() < (1-lambda/2.0)*fx.norm() || lambda < 1.0/64){
				run2 = false;
			}
		}//run2
		
		x = y;
		fx = fy;
		if(Dx.norm() < delta || fx.norm() < epsilon){
			run1 = false;
		}
		k = k+1;
		}//run1
		
		return x;
		
	}//newton

}//class
