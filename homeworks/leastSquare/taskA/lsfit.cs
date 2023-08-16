using System;
using static System.Math;

public static partial class lsfit{
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
	public static double[] fit(double[] xs, double[] ys, double[] dys, Func<double,double>[] funcs){
		int n = xs.Length;
		int m = funcs.Length;
		matrix A = new matrix(n,m);
		matrix Q = A.copy();
		matrix R = new matrix(m,m);
		vector b = new vector(n);
		for(int i=0; i<n; i++){ //Make matrix
			b[i] = ys[i]/dys[i];
			for(int j=0; j<m; j++){
				Q[i,j] = funcs[j](xs[i])/dys[i];
			}
		}
		//Decompose
		QRGS.decompose(Q,R);
		//Solving system
		vector c = QRGS.solve(Q,R,b);
		return c;
		
	}

}
