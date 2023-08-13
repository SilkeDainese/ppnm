all: Erf.svg gamma.svg lngamma.svg Out.txt

Erf.svg : Out.txt Makefile
	echo '\
	set term svg;\
	set out "$@";\
	set title "Error function ";\
	set xlabel "x-data";\
	set ylabel "y-data";\
	plot [-0.1:3.8][-0.1:1.6]\
	 "Out.txt" index 0 using 1:2 pointsize 1 title "Data from Wikipedia"\
	,"Out.txt" index 0 using 1:3 pointsize 0.5 title "Calculated values"\
	'|gnuplot

gamma.svg: Out.txt Makefile
	echo '\
	set term svg;\
	set out "$@";\
	set title "Gamma function: Gamma(n+1) = n!";\
	set xlabel "x-data";\
	set ylabel "y-data";\
	plot [0:9][-1:900]\
	 "Out.txt" index 1 using 1:2 pointsize 1 title "Calculated values"\
	,"Out.txt" index 2 using 1:2 pointsize 1 title "Factorials"\
	'|gnuplot

lngamma.svg : Out.txt Makefile
	echo '\
	set term svg;\
	set out "$@";\
	set title "Logarithm of Gamma function ";\
	set xlabel "x-data";\
	set ylabel "y-data";\
	plot [0:12][0:20]\
	 "Out.txt" index 1 using 1:3 pointsize 1 title "Calculated values"\
	,"Out.txt" index 2 using 1:3 pointsize 1 title "logarithm of Factorials"\
	'|gnuplot

Out.txt : main.exe Erf_wiki.txt
	mono $< < Erf_wiki.txt > $@

main.exe : main.cs math.dll
	mcs $< -reference:math.dll -target:exe -out:$@

math.dll : sfun.cs vec.cs
	mcs $^ -target:library -out:$@

clean : 
	rm -f Out.txt main.exe 
