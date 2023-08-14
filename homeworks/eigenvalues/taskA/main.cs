using System;
using static System.Console;
using static System.Math;
using static System.Random;

public class main{

	public static void Main(){
		int n = 3;
		int m = n;
		matrix A = new matrix(n,m);
		matrix V = new matrix(n,m);
		var rand = new Random();
		for(int i=0; i<n; i++){
			for(int j=0; j<m; j++){
				double number = rand.NextDouble();
				A[i,j] = number; //Hermitisk matrix
				A[j,i] = number;
			}
		}
		matrix D = A.copy();
		WriteLine($"Random generated {n} by {m} matrix");
		A.print();
		
		WriteLine($"\n");
		
		int sweeps = jacobev.JacobCyclic(D,V);
		WriteLine($"Jacob eigenvalue diagonalization of A. Number of sweeps={sweeps}");
		WriteLine($"Matrix D, with eigenvalues on the diagonal:");
		D.print();
		
		WriteLine($"\n");
		
		WriteLine($"Checking that V^T*A*V=D");
		matrix V_trans_A_V = V.transpose()*A*V;
		V_trans_A_V.print();
		WriteLine($"{V_trans_A_V.approx(D)}");

		WriteLine($"\n");

		WriteLine($"Checking that V*D*V^T=A");
		matrix V_D_V_trans = V*D*V.transpose();
		WriteLine($"{V_D_V_trans.approx(A)}");
		V_D_V_trans.print();	
	
		WriteLine($"\n");

		WriteLine($"Checking that V^T*V=I");
		matrix V_trans_V = V.transpose()*V;
		matrix I = new matrix(n,n);
		I.set_unity();
		WriteLine($"{V_trans_V.approx(I)}");
		V_trans_V.print();
	
		WriteLine($"\n");
	
		WriteLine($"Checking that V*V^T=I");
		matrix V_V_trans = V*V.transpose();
		WriteLine($"{V_V_trans.approx(I)}");
		V_V_trans.print();
	}
}
