Out.txt: main.exe
	mono main.exe > Out.txt

matrix.dll : vector.cs matrix.cs
	mcs -target:library -out:./matrix.dll $^

main.exe: main.cs matrix.dll
	mcs -reference:matrix.dll main.cs

clean: 
	rm -rf *.txt *.exe
