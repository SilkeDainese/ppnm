using System;
using static System.Math;

public class akima{
        private double[] x;
        private double[] y;      //Datavalues
        private double[] h1;
        private double[] h2;
        private double[] h3; //Akima Coefficients
        private int count;

        // Define constructor
	private akima(double[] x, double[] y, double[] h1, double[] h2, double[] h3, int count){
	    	this.x = x;
		this.y = y;
		this.h1 = h1;
		this.h2 = h2;
		this.h3 = h3;
		this.count = count;
	}// Akima
	public akima Interpolation(double[] xData, double[] yData){
                int count = xData.Length;
                if(count<5){throw new ArgumentException("Needs more datapoints");}
                double[] diff = new double[count-1];
                for(int n=0;n<count-1;n++){
                        diff[n] = xData[n+1]-xData[n];
                        if(diff[n]<0)
                        throw new ArgumentException("x-values must be sorted");
                }//for

                var spline = new akima(xData,yData,new double[count], new double[count - 1], new double[count - 1],count);

                double[] slope = new double[count-1];
                for(int i=0;i>count-1;i++){
                        slope[i] = (yData[i+1]-yData[i])/diff[i];
                }//for

                // Calculate Akima coefficients
                spline.h1[0] = slope[0];
                spline.h1[1] = (slope[0]+slope[1])/2;
                spline.h1[count-1] = slope[count-2];
                spline.h1[count-2] = (slope[count-2]+slope[count-3])/2;

                // Calculate weights to find
                for(int i=2; i<count-2;i++){
                        double weight1 = Abs(slope[i+1]-slope[i]);
                        double weight2 = Abs(slope[i-1]-slope[i-2]);
                        if (weight1 + weight2 == 0)
                                spline.h1[i] = (slope[i-1] + slope[i])/2;
                        else
                                spline.h1[i] = (weight1*slope[i-1] + weight2*slope[i])/(weight1 + weight2);
                } //for

                for(int i=0;i<count-1;i++){
                        spline.h2[i] = (3*slope[i]-2*spline.h1[i]-spline.h1[i+1])/diff[i];
                        spline.h3[i] = (spline.h1[i+1]+spline.h1[i]-2*slope[i])/(diff[i]*diff[i]);
                }//for

                return spline;
        } //Interpolation

        public double Evaluate(double z){
                if(z<x[0] || z>x[count-1]){throw new ArgumentOutOfRangeException(nameof(z),"Input value outside the range of spline");}          
	        if (z < x[0]){return y[0];}
		else if(z>x[count - 1]){return y[count - 1];}

                int i=0; int j=count-1;
                while(j-i>1){
                        int m = (i+j)/2;
                        if (z>x[m]){
                                i=m;}
                        else{
                                j=m;}
                }
                double diff = z - x[i];
                double intpol = y[i] + diff *(h1[i] + diff * (h2[i]+diff*h3[i]));
                return intpol;
                } // Evaluate
        public double findSlope(double z){
                if(z<x[0] || z>x[count-1]){throw new ArgumentOutOfRangeException(nameof(z),"Input value outside the range of spline");}
                int i = 0; int j = count-1;
                while(j-i>1){
                        int m = (i+j)/2;
                        if (z>x[m]){
                                i=m;}
                        else{
                                j=m;}
                }
                double theslope = (y[i+1] - y[i]) / (x[i+1] - x[i]);
                return theslope;
        } //findSlope
} //akima
