out.txt: main.exe
	mono $<  > $@

main.exe:: main.cs matrix.dll vector.dll jacobev.dll
	mcs $< -target:exe -reference:matrix.dll -reference:vector.dll -reference:jacobev.dll

jacobev.dll: jacobev.cs matrix.dll vector.dll
	mcs $< -target:library -reference:matrix.dll -reference:vector.dll

matrix.dll: matrix.cs vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll
 
vector.dll: vector.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library

PHONEY: clean
clean: 
	rm -f *.txt *.dll *.exe *.pdf
