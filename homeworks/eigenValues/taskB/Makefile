.PHONEY: default
default: out.txt rmax.pdf npoints.pdf eigenfunctions.pdf

out.txt: main.exe
	mono $<  | sed 's/,/./g' > $@

rmax.pdf: out.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 'rmax' \n\
	set ylabel 'energy' \n\
	set grid \n\
	set title 'rmax' \n\
	set key left top \n\
	plot [2:30] [] 'out.txt' index 0 using 1:2 with lines title 'E_0', \
		'out.txt' index 0 using 1:3 with lines title 'E_1', \
		'out.txt' index 0 using 1:4 with lines title 'E_2', \
		-0.4998 with lines dashtype 2 title 'E_0 analytical', \
		-0.1249 with lines dashtype 2 title 'E_1 analytical', \
		-0.05553 with lines dashtype 2 title 'E_2 analytical' \n\
	" | tee log.gpi | gnuplot

npoints.pdf: out.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 'npoints' \n\
	set ylabel 'energy' \n\
	set grid \n\
	set title 'npoints' \n\
	set key left top \n\
	plot [10:200] [] 'out.txt' index 1 using 1:2 with lines title 'E_0', \
		'out.txt' index 1 using 1:3 with lines title 'E_1', \
		'out.txt' index 1 using 1:4 with lines title 'E_2', \
		-0.4998 with lines dashtype 2 title 'E_0 analytical', \
		-0.1249 with lines dashtype 2 title 'E_1 analytical', \
		-0.05553 with lines dashtype 2 title 'E_2 analytical' \n\
	" | tee log.gpi | gnuplot

eigenfunctions.pdf: out.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 'radius' \n\
	set ylabel 'energy' \n\
	set grid \n\
	set key right top \n\
	set title 'Eigenfunctions' \n\
	plot [0:30] [-0.5:0.8] 'out.txt' index 2 using 1:2 with lines title 'R_{10}', \
		'out.txt' index 2 using 1:3 with lines title 'R_{20}', \
		'out.txt' index 2 using 1:4 with lines title 'R_{30}', \
		'out.txt' index 3 using 1:2 with lines dashtype 2 title 'R_{10} analytical', \
		'out.txt' index 3 using 1:3 with lines dashtype 2 title 'R_{20} analytical', \
		'out.txt' index 3 using 1:4 with lines dashtype 2 title 'R_{30} analytical' \n\
	" | tee log.gpi | gnuplot

main.exe: main.cs matrix.dll vector.dll jacobev.dll
	mcs $< -target:exe -reference:matrix.dll -reference:vector.dll -reference:jacobev.dll

jacobev.dll: matrix.dll vector.dll jacobev.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:matrix.dll -reference:vector.dll

matrix.dll: matrix.cs vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll
 
vector.dll: vector.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library

PHONEY: clean
clean: 
	rm -f *.txt *.dll *.exe *.pdf
