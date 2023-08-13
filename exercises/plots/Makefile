all: Error_function.svg Gamma_function.svg Lngamma_function.svg Out.txt

Error_function.svg : Out.txt Makefile
	echo '\
	set term svg;\
	set out "$@";\
	set title "Error function ";\
	set xlabel "x data";\
	set ylabel "y data";\
	plot [-0.2:4][-0.2:1.5]\
	 "Out.txt" index 0 using 1:2 pointsize 1 title "Wikipedia values"\
	,"Out.txt" index 0 using 1:3 pointsize 0.5 title "Computed values"\
	'|gnuplot

Gamma_function.svg: Out.txt Makefile
	echo '\
	set term svg;\
	set out "$@";\
	set title "Gamma function";\
	set xlabel "x data";\
	set ylabel "y data";\
	plot [0:8][-1:1000]\
	 "Out.txt" index 1 using 1:2 pointsize 1 title "Computed values"\
	,"Out.txt" index 2 using 1:2 pointsize 1 title "Factorials"\
	'|gnuplot

Lngamma_function.svg : Out.txt Makefile
	echo '\
	set term svg;\
	set out "$@";\
	set title "Logarithm of Gamma function ";\
	set xlabel "x data";\
	set ylabel "y data";\
	plot [0:12][0:20]\
	 "Out.txt" index 1 using 1:3 pointsize 1 title "Computed values"\
	,"Out.txt" index 2 using 1:3 pointsize 1 title "logarithm of Factorials"\
	'|gnuplot

Out.txt : main.exe Erf.txt
	mono $< < Erf.txt > $@

main.exe : main.cs math.dll
	mcs $< -reference:math.dll -target:exe -out:$@

math.dll : sfun.cs vectors.cs
	mcs $^ -target:library -out:$@

clean : 
	rm -f Out.txt main.exe 
