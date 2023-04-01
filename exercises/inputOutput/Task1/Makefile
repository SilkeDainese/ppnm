all: run

build:
	mcs main1.cs

run: build
	mono main1.exe $$(cat inputfile.cs) > out.txt


clean:
	-rm -f main1.exe out.txt
