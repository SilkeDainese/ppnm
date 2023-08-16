qspline_gnuplot.pdf: out.txt
	echo "\
	set terminal pdf \n\
	set output '$@' \n\
	set xlabel 'x' \n\
	set ylabel 'y' \n\
	set multiplot layout 1,3 \n\
	set key below  \n\
	plot [-5:5] [] 'out.txt' index 0 using 1:2 with points title 'Data points', \
		'out.txt' index 1 using 1:2 with lines title 'Quadratic', \
		'out.txt' index 1 using 1:3 with lines title 'Integral', \
		'out.txt' index 1 using 1:4 with lines title 'Derivative' \n\
	plot [-5:5] [] 'out.txt' index 2 using 1:2 with points title 'Data points', \
		'out.txt' index 3 using 1:2 with lines title 'Quadratic', \
		'out.txt' index 3 using 1:3 with lines title 'Integral', \
		'out.txt' index 3 using 1:4 with lines title 'Derivative' \n\
	plot [-5:5] [] 'out.txt' index 4 using 1:2 with points title 'Datapoints', \
		'out.txt' index 5 using 1:2 with lines title 'Quadratic', \
		'out.txt' index 5 using 1:3 with lines title 'Integral', \
		'out.txt' index 5 using 1:4 with lines title 'Derivative' \n\
	" | tee log.gpi | gnuplot

out.txt: main.exe
	mono $< | sed 's/,/./g' > $@

main.exe: main.cs qspline.dll
	mcs $< -target:exe -reference:qspline.dll

qspline.dll: qspline.cs
	mcs $< -target:library

PHONEY: clean
clean: 
	rm -r out.txt *.dll *.exe *.pdf
