using static System.Console;
using static System.Math;

static class epsilon{
	public static bool approx(double a,double b, double acc=1e-9, double esp=1e-9){
		if(Abs(b-a) < acc) return true;
		else if(Abs(b-a) < Max(Abs(a),Abs(b)*esp)) return true;
		else return false;
	}	
	static void Main(){
		Write("Excerise 1: \n");
		int i=1;
		while(i+1>i) {i++;}
		Write($"My max int is {i}\n");
		Write($"int.MaxValue is {int.MaxValue}\n");
		
		int j = 1;
		while(j-1<j) {j--;}
		Write($"My min int is {j}\n");
		Write($"int.MinValue is {int.MinValue}\n");


		Write("Exercise 2:\n");
		double x=1;
		while(1+x!=1){x/=2;}
		x*=2;
		Write($"The machine epsilon for doubles are {x}\n");
		float y=1F;
		while((float) (1F+y) != 1F) {y/=2F;}
		y*=2F;
		Write($"The machine epsilon for floats are {y}\n");


		Write("Exercise 3:\n");
		int n= (int) 1e6;
		double epsilon=Pow(2,-52);
		double tiny=epsilon/2;
		double sumA=0,sumB=0;
		sumA+=1;
		for(int k=0; k<n; k++) {sumA+=tiny;}
			Write($"sumA-1 = {sumA-1:e} should be {n*tiny:e}\n");
		for(int l=0; l<n;l++) {sumB+=tiny;}
			Write($"sumB-1 = {sumB - 1:e} should be {n*tiny:e}\n");


		Write("Exercise 4:\n");
		double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
		double d2 = 8*0.1;
				
		WriteLine($"d1={d1:e15}");
		WriteLine($"d2={d2:e15}");
		WriteLine($"d1==d2 ? => {d1==d2}");
		WriteLine($"d1==d2 using approx bool => {approx(d1,d2)}");
		
	}
}
