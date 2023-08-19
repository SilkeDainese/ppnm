.PHONEY: default
default: out.txt figure.pdf

out.txt: main.exe
	mono $< | sed 's/,/./g' > $@

main.exe: main.cs vector.dll matrix.dll minimization.dll ann.dll
	mcs $< -target:exe -reference:matrix.dll -reference:ann.dll -reference:vector.dll -reference:minimization.dll

ann.dll: ann.cs minimization.dll matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll  -reference:vector.dll -reference:minimization.dll

minimization.dll: minimization.cs matrix.dll vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll -reference:matrix.dll

matrix.dll: matrix.cs vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library

figure.pdf: out.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'g(x)' \n\
	set grid \n\
	set title 'Interpolation' \n\
	set key left top \n\
	plot [] [] 'out.txt' index 0 using 1:2 with points title 'Tabulated points', \
		'out.txt' index 1 using 1:2 with lines title 'ANN' \n\
	" | tee log.gpi | gnuplot


PHONEY: clean
clean:
	rm -f *.txt *.exe
