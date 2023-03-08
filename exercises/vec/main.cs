using System;
using static System.Console;
using static System.Math;
using static vec;
public static class main{

	public static void print(this double x,string s){ /* x.print("x="); */
		Write(s);WriteLine(x);
		}

	public static void print(this double x){ /* x.print() */
		x.print("");
	}

	public static void Main(){
		vec u = new vec(1,2,3);
		vec v = new vec(4,5,6);
		u.    print("u = ");
		v.    print("v = ");
		(u+v).print("u+v = ");
		(2*u).print("2u = ");
		vec p  = u*2;
		p.    print("u*2 = ");
		(-u). print("-u = ");
		vec w= 3*u-v;
	 	w.print("3*u-v = ");	
		
		double dotted = dot(u,v);
		WriteLine($"Dot product of u and v={dotted}");
		WriteLine($"Cross Product of u and v: {cross(u,v)}");
		WriteLine($"Norm of u: {norm(u)}");

		WriteLine(v.ToString());
		
		WriteLine($"approximation of w and 3*u-v : {vec.approx(w,3*u-v)}");
		WriteLine($"approximation of w and 3*u-v : {w.approx(3*u-v)}");
		WriteLine($"approximation of u and v : {u.approx(v)}");


	}
}


