.PHONEY: default
default: out.txt plot_fit.pdf

out.txt: main.exe
	mono $< | sed 's/,/./g' > $@

plot_fit.pdf: out.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 'Time[days]' \n\
	set ylabel 'Activity[rel. units]' \n\
	set grid \n\
	set key left top \n\
	plot [] [] 'out.txt' index 0 using 1:2:3 with yerrorbars title 'Data', \
		'out.txt' index 1 using 1:2 with lines title 'Fit' \n\
	" | tee log.gpi | gnuplot


main.exe: main.cs matrix.dll vector.dll lsfit.dll
	mcs $< -target:exe -reference:matrix.dll -reference:lineq.dll -reference:vector.dll -reference:lsfit.dll

lsfit.dll: lsfit.cs matrix.dll vector.dll
	mcs $< -target:library -reference:lineq.dll -reference:matrix.dll -reference:vector.dll

matrix.dll: matrix.cs vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll
 
vector.dll: vector.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library

PHONEY: clean
clean: 
	rm -f *.txt *.dll *.exe *.pdf
