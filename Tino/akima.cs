using silkes;
using static System.Math;

public class Akima
{
    private double[] xData;
	private double[] yData;
    private readonly double stepCount;
    private int count;
    private double[] b;
	private double[] c;
	private double[] d;




    public Akima(double[] xData, double[] yData, double stepCount )
    {
        this.xData = xData;
        this.yData = yData;
        this.stepCount = stepCount;
        count = xData.Length;
        b = new double[count];
        c = new double[count-1];
        d = new double[count-1];

    }


    public void Interpolation() // Should take arguments x and y
    {
        //Calculate slope
        var m = new double[count - 1];
        for (int i = 0; i < count - 1; i++)
        {
            m[i] = (yData[i + 1] - yData[i]) / (xData[i + 1] - xData[i]);
        }

        // Calculate weights and b coefficien
        b[0] = m[0];
        b[1] = (m[0] + m[1]) / 2;
        b[count - 1] = m[count - 2];
        b[count - 2] = (m[count - 2] + m[count - 3]) / 2;

        for (int i = 2; i < count - 2; i++)
        {

            double w1 = Abs(m[i + 1] - m[i]);
            double w2 = Abs(m[i - 1] - m[i - 2]);

            if (w1 + w2 == 0)
                b[i] = (w2 * m[i] + w1 * m[i + 1]) / (w1 + w2);
            else
                b[i] = (w1 * m[i - 1] + w2 * m[i]) / (w1 + w2);
            ;
        }

        // Calculate c and d akima coefficients
        for (int i = 0; i < count - 1; i++)
        {
            c[i] = (3 * m[i] - 2 * b[i] - b[i + 1]) / (xData[i + 1] - xData[i]);
            d[i] = (b[i + 1] + b[i] - 2 * m[i]) / (Math.Pow((xData[i + 1] - xData[i]), 2));
        }
    }

    // Interpolate - first find i in dx = x - x[i]


    public  List<double> SpaceListEvenly(List<double> originalList)
    {
        double min = originalList.Min();
        double max = originalList.Max();

        double interval = (max - min) / (stepCount - 1);

        var result = new List<double>();

        for (int i = 0; i < stepCount; i++)
        {
            result.Add(min + interval * i);
        }

        return result;
    }



    public Dto Evaluate()
        {

        var xPlot = SpaceListEvenly(xData.ToList());
        var yPlot = new List<double>();

        foreach (var xp in xPlot)
        {
            yPlot.Add(EvaluateInternal(xp));
        }

        var dto = new Dto()
        {
            Xvalues = xPlot,
            Yvalues = yPlot,
        };

        return dto;
        }

    private double EvaluateInternal(double z)
    {

        var i = 0;
        var j = count-1;

        while (j-i>1)
        {
            var m = (i+j)/2;
            if (z>xData[m])
            {
                i=m;
            }
            else
            {
                j=m;
            }
        }


        var dx = z - xData[i];

        return yData[i] + dx * (b[i] + dx * (c[i] + dx * d[i]));
    }
}

