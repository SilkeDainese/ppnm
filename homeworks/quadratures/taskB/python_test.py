import numpy as np
from scipy import integrate

def function1(x):
	return 1/np.sqrt(x)

def function2(x):
	return np.log(x)/np.sqrt(x)

result1, error1, infodict1 = integrate.quad(function1, 0, 1, epsabs=0.001, epsrel=0.001, full_output=True)
result2, error2, infodict2 = integrate.quad(function2, 0, 1, epsabs=0.001, epsrel=0.001, full_output=True)

print("Integration of 1/sqrt(x) from 0 to 1 = " + str(result1) + " and took " + str(infodict1['neval']) + " iterations")
print("Integration of ln(x)/sqrt(x) from 0 to 1 = " + str(result2) + " and took " + str(infodict2['neval']) + " iterations")
