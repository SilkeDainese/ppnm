using static System.Console;
using static System.Math;

public class vec{
	public double x,y,z;                                                  // Define x,y,z
	public vec (double a,double b,double c){ x=a; y=b; z=c; }             // Constructors
	public vec (){ x=y=z=0; }                                             // Constructors
	public void print(string s){Write(s);WriteLine($"{x} {y} {z}");}      // Define print method

	public static vec operator+(vec u,vec v){ /* u+v */                   // Overwrite operators to use for vectors
		return new vec(u.x+v.x,u.y+v.y,u.z+v.z);		      // + operator
			}

	public static vec operator-(vec u,vec v){ /* u-v */                   // - operator
		return new vec(u.x-v.x,u.y-v.y,u.z-v.z);
			}

	public static vec operator-(vec v){ /* -v */			      // - operator for 1 vector
		return new vec(-v.x,-v.y,-v.z);
			}

	public static vec operator*(vec u,double c){ /* u*c */		      // * operator for vector times scalar				
		return new vec(u.x*c,u.y*c,u.z*c);
	}

	public static vec operator*(double c,vec u){ /* c,*u */               // * operator for scalar times vector
		return u*c;
	}

	public static double operator% (vec u,vec v){ /* dot product */       // dot product of two vectors
		return u.x*v.x+u.y*v.y+u.z*v.z;
	}

	public static double dot (vec u,vec v){
		 return (u.x*v.x+u.y*v.y+u.z*v.z);
        }                                                                     // dot implemented using prvious % operator

	public static double norm(vec u){				      // norm of vector 
		double norm = (Sqrt(Pow(u.x,2)+Pow(u.y,2)+Pow(u.z,2)));
		return norm;
	}

	public static vec cross(vec u, vec v){                                // cross product
		return new vec(u.y*v.z-u.z*v.y, u.x*v.z-u.z*v.x, u.x*v.y-u.y*v.x);
	}

	// Override ToString method:
	public override string ToString(){
		return $"vec:({x} {y} {z})";
	}

	static bool approx(double a,double b,double acc=1e-9,double eps=1e-9){
	if(Abs(a-b)<acc)return true;
	if(Abs(a-b)<(Abs(a)+Abs(b))*eps)return true;
		return false;
	}
	public bool approx(vec other){
		if(!approx(this.x,other.x)) return false;
		if(!approx(this.y,other.y)) return false;
		if(!approx(this.z,other.z))return false;
	return true;
	}
public static bool approx(vec u, vec v) => u.approx(v);
}
