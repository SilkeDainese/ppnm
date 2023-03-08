using System;
using static System.Console;
using static System.Math;
public static class main{
	public static void Main(){
		/*
		int n=9;
		double[] a = new double[n];
		for(int i=0;i<n;i++) Write($"a[{i}] = {a[i]} ");	
		WriteLine();
		for(int i=0;i<n;i++) a[i]=i;
		for(int i=0;i<n;i++) Write ($"a[{i}] = {a[i]} ");
		WriteLine();
		WriteLine($"array length = {a.Length}");
		*/

		vec v = new vec(2,3,4);
		vec u = new vec(1,2,3);
		u.print("u =");
		v.print("v = ");
		(u+v).print("u´v = ");
		(2*u).print("2*u = ");
	}
}
