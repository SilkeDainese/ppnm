Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs vec.dll
	mcs main.cs -target:exe -out:main.exe

vec.dll : vec.cs
	mcs $< -target:libary -out:$@
