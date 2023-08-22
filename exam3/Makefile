All : testpoints.data interpolated.data plot.svg 

plot.svg : plot.gpi testpoints.data interpolated.data

testpoints.data : main.exe
		mono $< | sed 's/,/./g' > $@

main.exe: main.cs Akima.dll
		mcs $< -target:exe -reference:Akima.dll

Akima.dll: Akima.cs
	mcs -out:./$@ $(filter %.cs,$^) -target:library

PHONEY: clean
	clean: 
		rm -f *.txt *.dll *.exe *.pdf

