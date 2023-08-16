using System;
using static System.Console;
using static System.Math;

public class main{
	public static void Main(){
		//RMAX:
		using(var outfile = new System.IO.StreamWriter("function_log.txt")){
			outfile.WriteLine($"Investigation of convergance of energies with respect to rmax.");
			outfile.WriteLine($"The spacing dr is fixed(0.2 Borh) and rmax is from 2 to 30.");
			outfile.WriteLine($"The three lowest energies(eigenvalues), using Jacob EVD, will be kompared to analytical values.");
			outfile.WriteLine($"See plot rmax.pdf");
			outfile.WriteLine($"The three lowest eigenvalues converge.");
//		}

		
		//Building the Hamiltonian matrix:
		for(int r_max=2; r_max<30; r_max++){
			double rmax = r_max;
			double dr = 0.2;
			int npoints = (int)(rmax/dr-1);
			vector r = new vector(npoints);
			for(int i=0; i<npoints; i++){
				r[i] = dr*(i+1);
			}
			matrix H = new matrix(npoints,npoints);
			for(int i=0; i<npoints-1; i++){ //sets the diagonals of the H matrix
				matrix.set(H,i,i,-2);
				matrix.set(H,i,i+1,1);
				matrix.set(H,i+1,i,1);
			}
			matrix.set(H,npoints-1,npoints-1,-2);
			H *= -0.5/dr/dr;
			for(int i=0; i<npoints; i++){
				H[i,i] += -1/r[i];
			}
			
			//Eigenvalues from EVD
			matrix D = H.copy();
			matrix V = new matrix(npoints,npoints);
			V.set_unity();
			jacobev.JacobCyclic(D,V);
			//Output the result
			WriteLine($"{rmax} {D[0,0]} {D[1,1]} {D[2,2]}");
		}


		//NPOINTS:
			outfile.WriteLine($"________________________________________");
 			outfile.WriteLine($"Investigation of convergance of energies with respect to npoints.");
			outfile.WriteLine($"npoints goes from 10 to 200");
			outfile.WriteLine($"See plot npoints.pdf");
			outfile.WriteLine($"The three lowest eigenvalues converget");

		WriteLine($"\n");

		for(int npoints=10; npoints <= 200; npoints++){
			double dr=0.1;
			vector r = new vector(npoints);
			for(int i=0; i<npoints; i++){
				 r[i]=dr*(i+1);
			}
			matrix H = new matrix(npoints,npoints);
			for(int i=0; i<npoints-1; i++){
		  		matrix.set(H,i,i,-2);
				matrix.set(H,i,i+1,1);
				matrix.set(H,i+1,i,1);
		  	}
			matrix.set(H,npoints-1,npoints-1,-2);
			H*=-0.5/dr/dr;
			for(int i=0;i<npoints;i++){
				H[i,i]+=-1/r[i];
			}
			
			//Eigenvalues fromEVD
			matrix D = H.copy();
			matrix V = new matrix(npoints,npoints);
			V.set_unity();
			jacobev.JacobCyclic(D,V);
			//Output the result
			WriteLine($"{npoints} {D[0,0]} {D[1,1]} {D[2,2]}");

		}

		WriteLine($"\n");

		//Eigenfunctions(wavefunctions)
			outfile.WriteLine($"________________________________________");
			outfile.WriteLine($"Evaluation of the lowest eigenfunctions");
			outfile.WriteLine($"The parameters are rmax=30, npoints=200 and dr=0.2");
		
		int npoints1 = 200;
		double rmax1 = 30;
		double dr1 = 0.2;
		vector r1 = new vector(npoints1);	
		for(int i=0; i<npoints1; i++){
			r1[i] = dr1*(i+1);
		}
		matrix H1 = new matrix(npoints1,npoints1);
		for(int i=0; i<npoints1-1; i++){
			matrix.set(H1,i,i,-2);
			matrix.set(H1,i,i+1,1);
			matrix.set(H1,i+1,i,1);
		}
		matrix.set(H1,npoints1-1, npoints1-1,-2);
		H1 *= -0.5/dr1/dr1;
		for(int i=0; i<npoints1; i++){
			H1[i,i] += -1/r1[i];
		}
		//Eigenvalues fromEVD
		matrix D1 = H1.copy();
		matrix V1 = new matrix(npoints1,npoints1);
		V1.set_unity();
		jacobev.JacobCyclic(D1,V1);
		//Output the result and normalized
		for(int i=0; i<r1.size; i++){
			WriteLine($"{r1[i]} {V1[0][i]*1.0/Sqrt(dr1)} {-V1[1][i]*1.0/Sqrt(dr1)} {-V1[2][i]*1.0/Sqrt(dr1)}");
		}
		WriteLine($"\n");
		//Analytical result
		for(double x=0; x<rmax1; x+=1.0/16){
			double R1 = x*2*Exp(-x);
			double R2 = x*1.0/Sqrt(2)*(1-1.0/2*x)*Exp(-x/2);
			double R3 = x*2.0/(3*Sqrt(3))*(1-2.0/3*x+2.0/27*x*x)*Exp(-x/3);
			WriteLine($"{x} {R1} {R2} {R3}");
		}


		} //outfile

	
	}//Main

}//class
