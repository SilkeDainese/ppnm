
linspline_gnuplot.png: out.txt
	echo "\
	set terminal png \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set grid \n\
	set key left top \n\
	plot [0:6] [-1:1] 'out.txt' index 0 using 1:2 with points title 'Tabulated', \
	'out.txt' index 1 using 1:2 with lines title 'Linear interpolation', \
	'out.txt' index 1 using 1:3 with lines title 'Integral(cos(x))' \n\
	" | tee log.gpi | gnuplot


out.txt: main.exe
	mono $< | sed 's/,/./g' > $@

main.exe: main.cs linspline.dll
	mcs $< -target:exe -reference:linspline.dll

linspline.dll: linspline.cs
	mcs $< -target:library

PHONEY: clean
clean: 
	rm -r out.txt *.dll *.exe *.png
