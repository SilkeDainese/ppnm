using static System.Console;
using static System.Math;
static class main{
	static void Main(){
		double c = 2.5;
		vec v = new vec(1, 2, 3);
		vec u = new vec(2, 4, 6);
		WriteLine("Testing vector class.");
		v.print("v vector is: ");
                u.print("u vector is: ");

		(v + u).print("v + u is: ");
                (v - u).print("v - u is: ");

		(-v).print("-v is: ");
		vec t = c*v;
		t.print($"{c}*v is: ");
		vec r = v*c;
		r.print($"v*{c} is: ");
		Write($"u • v = {vec.dot(u,v)}\n");
		Write($"u × v = {vec.cross(u,v)}\n");
		Write("norm of v: ");WriteLine(vec.norm(v));
		Write("norm of v using static function:");WriteLine(vec.norm(v));
	
		WriteLine("[also here tested ToString override]");
	

	}
}
