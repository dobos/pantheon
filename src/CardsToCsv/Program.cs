using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddressList
{
    class Program
    {
        /// <summary>
        /// Convert many Card files into a single CSV file.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            try
            {
                (var infiles, var outfile) = ParseArgs(args);
                var cards = CardIO.ReadCardFilesAsync(new TxtCardFormatter(), infiles);

                // We could do some transformation, sorting, indexing or similar here

                using (var file = new StreamWriter(outfile))
                {
                    var formatter = new CsvListFormatter()
                    {
                        Columns = new string[] { "Id", "Name", "Address" }
                    };
                    await CardIO.WriteCardListAsync(formatter, file, cards);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                PrintUsage();
            }
        }

        /// <summary>
        /// Parse command-line arguments. The last one is the output CSV file,
        /// everything else on the argument list is an input file or file pattern.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static (string[], string) ParseArgs(string[] args)
        {
            // All parameters are file patterns except the last one
            // Last one is output parameters

            if (args.Length < 2)
            {
                throw new ArgumentException("At least 2 arguments must be specified.");
            }

            var infiles = new List<string>();
            for (int i = 0; i < args.Length - 1; i++)
            {
                // Windows command-line does not glob, we do that here
                var path = Path.GetDirectoryName(args[i]);
                var pattern = Path.GetFileName(args[i]);
                infiles.AddRange(Directory.GetFiles(path, pattern));
            }

            var outfile = args[args.Length - 1];

            return (infiles.ToArray(), outfile);
        }

        /// <summary>
        /// Prints program usage
        /// </summary>
        static void PrintUsage()
        {
            Console.WriteLine("Usage: addresslist.exe input_pattern [input_pattern, ...] output_file");
        }

    }
}
