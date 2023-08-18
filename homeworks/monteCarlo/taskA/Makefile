out.txt: main.exe
	mono $< > $@

main.exe: main.cs montecarlo.dll vector.dll
	mcs $< -target:exe -reference:vector.dll -reference:montecarlo.dll

montecarlo.dll: montecarlo.cs vector.dll
	mcs $< -target:library -reference:vector.dll 

vector.dll: vector.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library


PHONEY: clean
clean:
	rm -f *.txt *.exe
