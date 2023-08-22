## Examination project: Number 2 - Akima sub-spline
###Description
For my examination project, I have successfully implemented a comprehensive Akima interpolation and evaluation method in the file akima.cs. This project aims to provide a practical demonstration of the Akima sub-spline interpolation technique.

###Implementation
In [akima.cs]{akima.cs}, the core functionality is divided into two key methods:

###Interpolation Method
In this method, the program calculates the coefficients required for the Akima spline. It begins by computing slopes between adjacent data points and then proceeds to determine the necessary weights and coefficients for each spline segment.

###Evaluate Method
This method handles the actual interpolation process. It generates evenly spaced x values using the SpaceListEvenly function and evaluates the corresponding y values through the EvaluateInternal function. The latter function, employing a binary search, identifies the appropriate segment for interpolation. It then utilizes the coefficients obtained during the interpolation to calculate the interpolated y value.

###Execution
The main execution is outlined in the Program.cs file:

1. An array of random x and y values is generated.
2. These values are sorted and written to a file named "testpoints.data".
3. The Akima interpolation method is applied to these data points, resulting in a smoother curve.
4. The resulting interpolated curve is saved to another file named "interpolated.data"
5. The project further encompasses plotting this data, which is visualized in the output file "plot.svg".




