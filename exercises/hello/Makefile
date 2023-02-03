Out.txt : main.exe                 # Out.txt (dependancy) is made from on main.exe () (Blanks are unimportant)
	mono main.exe > Out.txt    # Run main.exe, main.exe prints what it will print in terminal in out.txt)

main.exe:main.cs
	mcs main.cs -out:main.exe -target:exe  # Compile main.cs into main.cs

clean:
	rm --force Out.txt main.exe # Remove secondary filed

test-shell:
	echo $$0
