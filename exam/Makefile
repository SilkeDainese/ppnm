# Declare the targets
all: plot.svg

# Target to generate the plot.svg file
plot.svg: plot.gpi interpolated.data
	gnuplot plot.gpi

# Generate interpolated.data using the Program.exe
interpolated.data: Program.exe
	mono Program.exe > $@

# Compile the C# program
Program.exe: Program.cs akima.dll dto.cs
	mcs Program.cs dto.cs -reference:akima.dll

# Compile Akima.dll libary
akima.dll: akima.cs dto.cs
	mcs -target:library -out:$@ $^

# Declare the clean target
.PHONY: clean
clean:
	rm -f *.txt *.dll *.exe *.pdf

