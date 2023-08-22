using System;
using static System.Console;
using static System.Math;

public class minimization{
		
    public static vector ComputeGradient(Func<vector,double> objectiveFunction, vector x){
        int n = x.size;
        vector gradient = new vector(n);
        double functionValueAtX = objectiveFunction(x);
        double epsilon = Pow(2,-26);

        for(int i=0; i<n; i++){
            double dx = Abs(x[i])*epsilon;
            if(Abs(x[i]) < Sqrt(epsilon)){
                dx = epsilon;
            }
            x[i] += dx;
            gradient[i] = (objectiveFunction(x) - functionValueAtX) / dx;
            x[i] -= dx;
        }

        return gradient;
    }

    public static vector qnewton(Func<vector,double> objectiveFunction, vector xStart, double accuracy){
        vector x = xStart.copy();
        int n = x.size;
        int step = 0;
        double epsilon = Pow(2,-26);
        vector gradient = ComputeGradient(objectiveFunction, x);
        double functionValue = objectiveFunction(x);
        matrix B = new matrix(n,n);
        B.set_unity();

        while(accuracy < gradient.norm() && step < 10000){
            step++;
            vector dx = -B * gradient;
            
            if(dx.norm() < epsilon * x.norm() || dx.norm() < accuracy){
                Error.WriteLine("dx < deltax");
            }

            vector z;
            double fz, lambda = 1.0;
            while(true){
                z = x + dx * lambda;
                fz = objectiveFunction(z);
                if(fz < functionValue){ break; }
                if(lambda < epsilon){
                    B.set_unity();
                    break;
                }
                lambda /= 2;
            }
            
            vector s = z - x;
            vector gradientZ = ComputeGradient(objectiveFunction, z);
            vector y = gradientZ - gradient;
            vector u = s - B * y;
            double uTransposedY = u.dot(y);

            if(Abs(uTransposedY) > 1e-6){
                B.update(u, u, 1/uTransposedY);
            } else {
                B.set_unity();
            }

            x = z;
            gradient = gradientZ;
            functionValue = fz;
        }

        return x;
    }
}
