out.txt: main.exe
	mono $< > $@

main.exe: main.cs  integration.dll
	mcs $< -target:exe -reference:integration.dll

integration.dll: integration.cs
	mcs  $< -target:library


PHONEY: clean
clean:
	rm -f *.txt *.exe
