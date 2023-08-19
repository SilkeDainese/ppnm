.PHONEY: default
default: out.txt higgs.pdf fit1.txt

out.txt fit.txt: main.exe data1.txt
	mono $< < data1.txt 1> out.txt 2> fit.txt

main.exe: main.cs vector.dll matrix.dll minimization.dll
	mcs $< -target:exe -reference:matrix.dll  -reference:vector.dll -reference:minimization.dll

minimization.dll: minimization.cs matrix.dll vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll -reference:matrix.dll

matrix.dll: matrix.cs vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library

fit1.txt: fit.txt #Min computer laver komma tal og gnuplot skal bruge punktum tal
	sed 's/,/./g' fit.txt > fit1.txt

data1.txt: data.txt #Min computer læser komma og ikke punktum så når jeg indlæser en fil med punktum skal det laves til komma eller virker det ikke
	sed 's/\./,/g' data.txt > data1.txt

higgs.pdf: fit1.txt data.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 'Energy[GeV]' \n\
	set ylabel 'Cross section[arb. units]' \n\
	set grid \n\
	set title 'Higgs boson' \n\
	set key left top \n\
	plot [] [] 'data.txt' index 0 using 1:2:3 with yerrorbars title 'Data points', \
		'fit1.txt' index 0 using 1:2 with lines title 'Fit' \n\
	" | tee log.gpi | gnuplot


PHONEY: clean
clean:
	rm -f  *.exe *.pdf
