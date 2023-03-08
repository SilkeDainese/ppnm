using static System.Console
public class vec{
	public double x,y,z;
	public vec (double a,double b, double c){x=a;y=b;z=c;}
	public vec(0) {x=y=z=0;}
	public void print(string s){Write(s);WriteLine($"{x} {y} {z}")}
	public static vec operator+(vec u, vec v){ /* u+v */
		return new vec(u.x+v.x,u.y +v.y, u.z + v.z);
		} 
	public static vec operator*(vec u, double c){ /* u*c */
		return new vec(u.v*x,u.y*c,u.z*c);
		}	
	public static vec operator*(double c,vec c){
		return u*c;


}}

