using System;
using static System.Math;
using static System.Console;
using static System.Random;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class main{

	public static double Func(double x){ return Math.Sin(x);}

	public static void Main(string[] args){
        
		var random = new Random();
        	int dataSize=random.Next(10, 50);

        	double[] xsData = new double[dataSize];
        	double[] ysData = new double[dataSize];

        	for(int i=0;i<dataSize; i++)
        	{
            		xsData[i] = random.NextDouble();
            		ysData[i] = random.NextDouble();
        	}

        	Array.Sort(xsData, ysData);
	
		foreach(var arg in args)
        	{
            		if(arg == "test")
            	{
                
				for(int i=0;i<dataSize;i++)
                		{
                    			WriteLine($"{xsData[i]} {ysData[i]}");
                		}
            	}
		
	
	    		else if(arg=="Akima_Slope")
	    		{
                		double[] x = {-5,-4,-2.5,-1,0,2.5,5,7.5,10};
                		double[] y = {0,3,6,30,10,8,6,3,0};

				akima spline = new akima();
				spline.Interpolation(x,y);
			
				for(double dx=x.Min()+1.0/100;dx<=x.Max();dx+=1.0/100){

    					double interpolatedValue = spline.Evaluate(dx);
					double slope = spline.findSlope(dx);
				
					WriteLine($"{dx} {interpolatedValue} {slope}");
				}
	    		}
		
			else if(arg=="dataPoints")
			{
                		double[] x = {-5,-4,-2.5,-1,0,2.5,5,7.5,10};
                		double[] y = {0,3,6,30,10,8,6,3,0};


				for(int i=0; i<x.Length-1;i++)
				{
					WriteLine($"{x[i]} {y[i]}");
				}
			}

	    		else if(arg=="CubeSlope")
	    		{	
                		double[] x = {-5,-4,-2.5,-1,0,2.5,5,7.5,10};
                		double[] y = {0,3,6,30,10,8,6,3,0};



        		// Build the cubic spline interpolation
        			int n = x.Length;
        			double[] b = new double[n];
        			double[] c = new double[n - 1];
        			double[] d = new double[n - 1];
        			double[] A = new double[n];
        			double[] D = new double[n];
        			double[] Q = new double[n];
        			double[] B = new double[n];

        			CubeSpline.cspline_build(x, y, b, c, d, A, D, Q, B);

        		// Interpolate values in a loop
        			double minX = x[0];
        			double maxX = x[n - 1];
        			double step = 1.0 / 1000;

        			for(double i = minX+step; i<maxX; i+=step)
        			{
            				double interpolatedValue = CubeSpline.cspline_evaluate(x, y, b, c, d, i);
            				double slope = CubeSpline.cspline_diff(x, y, b, c, d, i);
            				WriteLine("{0} {1} {2}", i, interpolatedValue, slope);
        			}

	    		}		    
	 
            		else if(arg=="AkimaSubSplineInetpolation")
            		{
                		var rnd_data = File.ReadAllText("testpoints.data").Split("\n");
                		int fileDataSize = rnd_data.Length - 1;
                
                		// Resize arrays if needed
                		if(fileDataSize>dataSize)
                		{
                    			xsData = new double[fileDataSize];
                    			ysData = new double[fileDataSize];
                		}

                		for(int i=0;i<fileDataSize;i++)
                		{
                    			var xys = rnd_data[i].Split(' ');
                    			var x = xys[0].Replace(",", ".");
                    			var y = xys[1].Replace(",", ".");
                    			double.TryParse(x, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out xsData[i]);
                    			double.TryParse(y, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out ysData[i]);
                		}

                		Array.Sort(xsData, ysData);
                		akima spline = akima.Interpolation(xsData, ysData);

                		double startInterpValue = xsData.Min();
                		double endInterpValue = xsData.Max();

                		for(double dx=startInterpValue; dx<=endInterpValue; dx+=1.0/1000)
                		{
                    			double interpolatedValue = spline.Evaluate(dx);
                    			WriteLine($"{dx} {interpolatedValue}");
                		}
            		}
		
        	}
	}//Main
}//main
