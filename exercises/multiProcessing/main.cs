using System;
using System.Threading;
using System.Threading.Tasks;

public class data{
	public int a, b;
	public double sum;
}

class Program{
	public static void harmonic(object obj)
	{
		var local = (data)obj;
		local.sum = 0;
		for (int i = local.a; i < local.b; i++) local.sum += 1.0 / i;
	}

	static void Main(string[] args)
	{
	int nthreads = 1, nterms = (int)1e8; /* default values */
	foreach (var arg in args)
	{
		var words = arg.Split(':');
		if (words[0] == "-threads") nthreads = int.Parse(words[1]);
		if (words[0] == "-terms") nterms = (int)float.Parse(words[1]);
	}

	data[] x = new data[nthreads];
        for (int i = 0; i < nthreads; i++)
        {
		x[i] = new data();
		x[i].a = 1 + nterms / nthreads * i;
		x[i].b = 1 + nterms / nthreads * (i + 1);
        }
        x[x.Length - 1].b = nterms + 1;

	var threads = new Thread[nthreads];
	for (int i = 0; i < nthreads; i++)
	{
		threads[i] = new Thread(harmonic);
		threads[i].Start(x[i]);
        
	}
	
	for (int i = 0; i < nthreads; i++) threads[i].Join();

	double total = 0;
        for (int i = 0; i < nthreads; i++) total += x[i].sum;

	Console.WriteLine("Total sum: " + total);
 
 	double sum = 0;

	Parallel.For(1, nterms + 1, delegate (int i) { sum += 1.0 / i; });
        Console.WriteLine("Parallel.For sum: " + sum);
	}
}

