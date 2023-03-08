using static System.Math;
using static System.Console;

static public class math {
	static void Main() {
		double sqrt2 = Sqrt(2.0);
		double two1_5 = Pow(2,0.2);
		double epi = Pow(E, PI);
		double pie = Pow(PI, E);
		Write($"sqrt(2) = {sqrt2}\n");
		Write($"2^(1/5) = {two1_5}\n");
		Write($"sqrt2*sqrt2 = {sqrt2*sqrt2} (should be equal to 2)\n");
		Write($"e^pi = {epi}\n");
		WriteLine($"pi^e = {pie}\n");

		Write($"gamma(1) = {sfunc.gamma(1)}\n");

		Write($"gamma(2) = {sfunc.gamma(2)}\n");
		Write($"gamma(10) = {sfunc.gamma(10)}\n");
		Write($"lngamma(1) = {sfunc.lngamma(1)}\n");
		Write($"lngamma(-0.1) = {sfunc.lngamma(-0.1)}\n");
}
}
