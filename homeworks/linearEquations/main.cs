using System;
using static System.Console;
using static System.Math;
using static System.Random;

class main{
	public static class QRGS{
		// Decomp function
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
		
		// Determinant function
		public static double det(matrix matrixR){
			double product = 1.0;
			for(int i=0;i<matrixR.size1;i++){
				product = product * matrixR[i,i];
			}
			return product;
		}

		// Inverse function
		public static matrix inverse(matrix matrixQ, matrix matrixR){
			matrix inverseMatrix = new matrix(matrixQ.size1, matrixQ.size2);
			for(int i=0;i<matrixQ.size2;i++){
				vector unitVector  = new vector(matrixQ.size2);
				unitVector[i] = 1;
				inverseMatrix[i] = QRGS.solve(matrixQ, matrixR, unitVector);
			}
			return inverseMatrix;
		}
				
	}


	static void Main(){
		// TASK A
		WriteLine("TASK A: Solve linear equations using QR decomposition");

		//random tall
		var random = new Random();
		int random_n = random.Next(2,7);
		int random_m = random.Next(2,random_n);
		matrix random_a = new matrix(random_n, random_m);
		for(int i=0;i<random_n;i++){
			for(int j=0;j<random_m;j++){
				random_a[i,j] = random.NextDouble();
			}
		}
		
		//random quadratic
		int random_s = random.Next(2,7);
		matrix random_quad = new matrix(random_s, random_s);
		for(int i=0;i<random_s;i++){
			for(int j=0;j<random_s;j++){
				random_quad[i,j] = random.NextDouble();
			}
		}

		//random vector
		vector random_v = new vector(random_s);
		for(int i=0;i<random_s;i++){
			random_v[i] = random.NextDouble();
		}
		
		//check that decomp is working
		matrix a = random_a.copy();
		matrix r = new matrix(random_m, random_m);

		a.print("This is A before decomposition");
		r.print("This is R before decomposition");

		QRGS.decompose(a, r);

		a.print("This is Q after decomposition");
		r.print("This is R after decomposition");

		matrix check1 = a.T*a;
		matrix check2 = a*r;

                WriteLine("Check status:");

                r.set_unity();
                if(check1.approx(r)){
                        WriteLine("Q_transpose * Q equals identity matrix.");
                }
                else{
                        WriteLine("Q_transpose * Q does not equal identity matrix");
                }
                if(random_a.approx(check2)){
                        WriteLine("QR is identical with original A.");
                }
                else{
                        WriteLine("QR is not equal to original A.");
		}
		WriteLine("");

		//check that solve is working
		WriteLine("The following is the check for the solve function:");
		matrix A = random_quad;
		matrix R = new matrix(random_s, random_s);
		vector c = random_v;

		A.print("A:");
		c.print("b:");

		QRGS.decompose(A, R);
		vector x = QRGS.solve(A, R, c);
		x.print("x:");

		vector check3 = (A*R)*x;

		if(c.approx(check3)){
			WriteLine("Ax is equal to b.");
		}
		else{
			WriteLine("Ax is not equal to b.");
		}

		// TASK B
		WriteLine("TASK B: Matrix inverse using QR Decomposition");

		//random sqaure matrix
                int rand_s = random.Next(2,7);
                matrix A_b = new matrix(rand_s, rand_s);
                for(int i=0;i<rand_s;i++){
                        for(int j=0;j<rand_s;j++){
                                A_b[i,j] = random.NextDouble();
                        }
                }
		A_b.print("Matrix A:");

		// check inverse function
		matrix Q_b = A_b.copy();
		matrix R_b = new matrix(Q_b.size2, Q_b.size2);
		QRGS.decompose(Q_b, R_b);
		matrix B = QRGS.inverse(Q_b, R_b);
		B.print("Matrix B:");

		matrix check4 = A_b*B;
		R_b.set_unity();
		if(R_b.approx(check4)){
			WriteLine("Matrix B is the inverse of Matrix A.");
		}
		else{
			WriteLine("Matrix B is not the inverse of Matrix A.");
		}
		

	}
}	
