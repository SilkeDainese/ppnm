using System;
using static System.Math;

class main{
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
}
