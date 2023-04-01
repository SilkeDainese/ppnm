using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string infile = null, outfile = null;
        foreach (var arg in args)
        {
            var words = arg.Split(':');
            if (words[0] == "-input") infile = words[1];
            if (words[0] == "-output") outfile = words[1];
        }
        if (infile == null || outfile == null)
        {
            Console.Error.WriteLine("Usage: mono Program.exe -input:<inputfile> -output:<outputfile>");
            Environment.Exit(1);
        }

        try
        {
            using (var instream = new StreamReader(infile))
            using (var outstream = new StreamWriter(outfile, append: false))
            {
                string line;
                while ((line = instream.ReadLine()) != null)
                {
                    double x = double.Parse(line);
                    outstream.WriteLine($"{x} {Math.Sin(x)} {Math.Cos(x)}");
                }
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.Message);
            Environment.Exit(1);
        }
    }
}
