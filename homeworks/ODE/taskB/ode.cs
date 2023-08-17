using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

public static partial class ode{

public static (vector, vector) rkstep12(
	Func<double, vector, vector > f, /*the f from dy/dx=f(x,y), x double, y vector and return vector f*/
	double x,    /* the current value of the variable */
	vector y,                    /* the current value y(x) of the sought function */
	double h                     /* the step to be taken */
	){
	vector k0 = f(x,y);	/* embedded lower order formula (Euler) */
	vector k1 = f(x+h/2,y+k0*(h/2));	/* higher order formula (midpoint) */
	vector yh = y+k1*h;	/* y(x+h) estimate */
	vector er = (k1-k0)*h;	/* error estimate */
	return (yh,er);

}//rkstep12




public static (vector, vector) rkstep45(
        Func<double, vector, vector > f, /*the f from dy/dx=f(x,y), x double, y vector and return vector f*/
        double x,    /* the current value of the variable */
        vector y,                    /* the current value y(x) of the sought function */
        double h                     /* the step to be taken */
        ){
        vector k1 = f(x,y); 
	vector k2 = f(x+1.0/4*h,y+1.0/4*h*k1);
	vector k3 = f(x+3.0/8*h,y+3.0/32*h*k1+9.0/32*h*k2);
	vector k4 = f(x+12.0/13*h,y+1932.0/2197*h*k1-7200.0/2197*h*k2+7296.0/2197*h*k3);
	vector k5 = f(x+h,y+439.0/216*h*k1-8*h*k2+3680.0/513*h*k3-845.0/4104*h*k4);
	vector k6 = f(x+1.0/2*h,y-8.0/27*h*k1+2*h*k2-3544/2565*h*k3+1859.0/4104*h*k4-11.0/40*h*k5);
	vector ka = 16.0/135*k1+0*k2+6656.0/12825*k3+28561.0/56430*k4-9.0/50*k5+2.0/55*k6;
	vector kb = 25.0/216*k1+0*k2+1408.0/2565*k3+2197.0/4104*k4-1.0/5*k5+0*k6; 
        vector yh = y+h*ka;     /* y(x+h) estimate */
        vector er = (ka-kb)*h;  /* error estimate */
        return (yh,er);

}//rkstep45

public static vector driver(
	Func<double,vector,vector> F, /* the f from dy/dx=f(x,y) */
	double a,                    /* the start-point a */
	vector ya,                   /* y(a) */
	double b,                    /* the end-point of the integration */
	genlist<double> xlist=null, genlist<vector> ylist=null,
	double h=0.01,               /* initial step-size */
	double acc=0.01,             /* absolute accuracy goal */
	double eps=0.01              /* relative accuracy goal */
){
if(a>b) throw new ArgumentException("driver: a>b");
double x=a; vector y=ya.copy();
if(xlist!=null){xlist.add(x);}
if(ylist!=null){ylist.add(y);}

do      {
        if(x>=b) return y; /* job done */
        if(x+h>b) h=b-x;               /* last step should end at b */
        var (yh,err) = rkstep45(F,x,y,h);
	Error.WriteLine("rkstep45 done");
	vector tol = new vector(err.size);
        for(int i=0;i<y.size;i++)
		tol[i]=Max(acc,Abs(yh[i])*eps)*Sqrt(h/(b-a));
		Error.WriteLine($"toli");
	bool ok=true;
	for(int i=0;i<y.size;i++)
		if(!(err[i]<tol[i])) ok=false;
	if(ok){ 
		x+=h; y=yh;
		if(xlist!=null)xlist.add(x);
		if(ylist!=null)ylist.add(y);
		}
	double factor = tol[0]/Abs(err[0]);
	for(int i=1;i<y.size;i++) factor=Min(factor,tol[i]/Abs(err[i]));
	h *= Min( Pow(factor,0.25)*0.95 ,2);
        }while(true);
}//driver

}//class
