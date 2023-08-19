out.txt: main.exe
	mono $< > $@

main.exe: main.cs vector.dll matrix.dll minimization.dll
	mcs $< -target:exe -reference:matrix.dll  -reference:vector.dll -reference:minimization.dll

minimization.dll: minimization.cs matrix.dll vector.dll
	mcs $< -target:library -reference:vector.dll -reference:matrix.dll

matrix.dll: matrix.cs vector.dll
	mcs -out:./$@ $(filter %.cs,$^) -target:library -reference:vector.dll

vector.dll: vector.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library


PHONEY: clean
clean:
	rm -f *.txt *.exe
