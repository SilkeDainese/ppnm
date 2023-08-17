all : LotkaVolterraSystem.svg Out.txt
DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)
MKEXE = mcs -target:exe -out:$@ $(DLLS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(DLLS) $(CODE)

LotkaVolterraSystem.svg : lotkaVolterraSystem.gpi out.LotkaVolterraSystem.txt
	gnuplot $<

out.LotkaVolterraSystem.txt : main.exe
	mono $< 1> $@ 2> log

Out.txt :
	@echo Part B is performed where the Driver in ode.cs is imporved. This is done such that the driver records the path only if the generic lists for x and y are initialized. If the lists are null the driver only return y. Also the acceptence are cnaghed. >> Out.txt
	@echo  >> Out.txt
	@echo An example Lotka-Volterra system are reproduced. See LotkaVolterraSystem.svg >> Out.txt

main.exe : main.cs matlib.dll
	$(MKEXE)

matlib.dll : ode.cs vector.cs genlist.cs
	$(MKLIB)


i.PHONY: clean
clean:
	-$(RM) out* *.txt *.exe *.dll *.data
