using System;
using static System.Math;

public class akima
{
	
	public akima(double[] xData, double[] yData)
		x = xData;
		y = yData;
		int n = xData.Length;
		b = new double[n];
		c = new double[n-1];
		d = new double[n-1];
		
	public void Interpolation() // Should take arguments x and y
	{
		//Calculate slope
		double m  = new double[n-1]; 
		for(int i=0;i<n-1;i++)
		{
			m[i]= (y[i+1]-y[i])/(x[i+1]-x[i]);	 
		}
		
		// Calculate weights and b coefficien
		b[0]=m[0];
		b[1]=(m[0]+m[1])/2;
		b[m-1]=m[n-2];
		b[n-2]=(m[n-2]+m[n-3])/2;

		for(int i=2; i<n-2;i++){
			double w1=np.abs(m[i+1]-m[i]);
		        double w2=np.abs(m[i-1]-m[i-2]);
			if w1[i] + w1[i+1] == 0
				b[i] = (w1[i+1]*m[i]+w[i]*m[i+1]) / (w[0] + w[1]); 
			else 
		}		b[i] = (w1*m[i-1]+ w2*m[i])/(w1+w2);;
		
		// Calculate c and d akima coefficients
		for(int i=0;i<n-1;i++)
		{
			c[i] = (3 * m[i] - 2 * b[i]] - b[i+1]) / (x[i+1] - x[i]);
			d[i] = [(b[i+1] + b[i] - 2 * m[i]) / ((x[i+1] - x[i]) ** 2);
		}

		// Interpolate - first find i in dx = x - x[i]
		
		public Evaluate(double z)
		{
			i=0;
			j=n-1;
			while(j-i>1):
				integer = (i+j)/2;
		        	if(z>x[integer])
				{
					i=integer;
				}
        			else
				{
		  			j=integer;
				}
			}
			double dx = z - x[i];
			double interpolatedValue = y[i] + dx * (b[i] + dx * (c[i] + dx * d[i]));
			return interpolatedValue

		double xMin = x.Min();
		double xMax = x.Max();
		//double x_plot = range(X_min,Xmax)
		y_plot = new double[x_plot.Length];  
		for(int i = 0;i<x_plot.Length;i++)
		{
			double y_plot[i] = Evaluate(x_plot[i])
		}
		return (x_plot,y_plot)	
		// fix return
	// Want to return the interpolate value
	}	
}

