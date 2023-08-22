# Declare the targets
all: plot.svg CubicAkima.svg

# Target to generate the plot.svg file
plot.svg: plot.gpi interpolated.data
	gnuplot plot.gpi

CubicAkima.svg: CubicAkima.gpi Akimacompare.data Cubic.data points.data
	gnuplot CubicAkima.gpi 
# Generate interpolated.data using the Program.exe
interpolated.data: Program.exe
	mono Program.exe > $@

Akimacompare.data: Program.exe
	mono Program.exe > $@

Cubic.data: Program.exe
	mono Program.exe > $@
# Compile the C# program
Program.exe: Program.cs akima.dll dto.cs Cubic.dll
	mcs Program.cs dto.cs -reference:akima.dll -reference:Cubic.dll

# Compile Cubic.dll libary
Cubic.dll: Cubic.cs dto.cs
	mcs -target:library -out:$@ $^

# Compile Akima.dll libary
akima.dll: akima.cs dto.cs
	mcs -target:library -out:$@ $^

# Declare the clean target
.PHONY: clean
clean:
	rm -f *.txt *.dll *.exe *.pdf

