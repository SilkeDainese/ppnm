using static System.Console;
using static System.Math;

static class epsilon{
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

		Write("Exercise 2");

	}
}
