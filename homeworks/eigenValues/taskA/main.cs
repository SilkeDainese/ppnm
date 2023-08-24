using System;
using static System.Console;
using static System.Math;
using Random = System.Random;

public class main{

    public static void Main() {
        int matrixSize = 3;
        int dimension = matrixSize;
        matrix A = new matrix(matrixSize, dimension);
        matrix V = new matrix(matrixSize, dimension);
        var randomGenerator = new Random();

        for (int i = 0; i < matrixSize; i++) {
            for (int j = 0; j < dimension; j++) {
                double randomNumber = randomGenerator.NextDouble();
                A[i, j] = randomNumber; 
                A[j, i] = randomNumber;
            }
        }

        matrix D = A.copy();
        WriteLine($"Randomly generated {matrixSize} by {dimension} matrix");
        A.print();

        WriteLine($"\n");

        int sweepCount =jacobev.JacobCyclic(D,V); 
        WriteLine($"Eigenvalue diagonalization of A using Jacobi method. Number of sweeps = {sweepCount}");
        WriteLine($"Matrix D, with eigenvalues on the diagonal:");
        D.print();

        WriteLine($"\n");

        WriteLine($"Verifying that V^T * A * V = D");
        matrix VTransAV = V.transpose() * A * V;
        VTransAV.print();
        WriteLine($"{VTransAV.approx(D)}");

        WriteLine($"\n");

        WriteLine($"Verifying that V * D * V^T = A");
        matrix VDVT = V * D * V.transpose();
        VDVT.print();
        WriteLine($"{VDVT.approx(A)}");

        WriteLine($"\n");

        WriteLine($"Verifying that V^T * V = I");
        matrix VTransV = V.transpose() * V;
        matrix identity = new matrix(matrixSize, matrixSize);
        identity.set_unity();
        WriteLine($"{VTransV.approx(identity)}");
        VTransV.print();

        WriteLine($"\n");

        WriteLine($"Verifying that V * V^T = I");
        matrix VVTrans = V * V.transpose();
        WriteLine($"{VVTrans.approx(identity)}");
        VVTrans.print();
    }
}
