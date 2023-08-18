out.txt: main.exe
	mono $< > $@

main.exe: main.cs integration.dll python_result.txt
	mcs $< -target:exe -reference:integration.dll

integration.dll: integration.cs
	mcs $< -target:library

python_result.txt: python_test.py
	python3 $< > $@

PHONEY: clean
clean: 
	rm -f *.txt *.exe
