all: Out.txt
	car $<

Out.txt: main.exe
	mono $< >$@

main.exe : main.cs cmath.dll
	mcs -reference:cmath.dll main.cs

clean:
	rm -rf Out.txt main.exe

DIR = /Users/silke/source/repos/ppnm/exercises/complex/ 


cmath.dll: $(DIR)/cmath.cs $(DIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^
