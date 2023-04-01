all: Out.txt main1.exe main2.exe 

Out.txt: main1.exe main2.exe Makefile
	> $@
	
	echo "Reading numbers from command-line arguments:" >> $@
	mono Task1/main1.exe -numbers:1,2,3,4,5 >> $@

	echo "Reading numbers from standar input" >>$@
	echo Task2/main2.exe <Task2/input2.cs >>$@ 

	echo "Reading numbers from a file and writing to a file:" >>$@
	mono Task3/main3.exe -input:Task3/inputfile.txt -output:Task3/outputfile.txt \
		1>>$@ 2>>log

	echo "here is a copy of the output:" >>$@
	cat Task3/outputfile.txt >> $@

main1.exe : Task1/main1.cs
	mcs -out:Task1/main1.exe $^

main2.exe : Task2/main2.cs
	mcs -out:Task2/main2.exe $^

main3.exe : Exercise3/main3.cs
	mcs -out:Exercise3/main3.exe $^

.PHONEY: clean
clean:
	rm -f *.exe Out.txt log
