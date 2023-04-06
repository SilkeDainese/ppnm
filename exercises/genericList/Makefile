EXE = main.exe
SRC = main.cs
INP = input.txt
OUT = Out.txt
DLL = genlist.dll
DCS = genlist.cs

$(OUT): $(EXE) $(INP)
	mono $(EXE) < $(INP) > $(OUT)

$(EXE): $(SRC) $(DLL)
	mcs $(SRC) -target:exe -reference:$(DLL) -out:$(EXE)

$(DLL): $(DCS)
	mcs $< -target:library

clean:
	rm -f $(EXE) $(DLL) *.mdb *.pdb
