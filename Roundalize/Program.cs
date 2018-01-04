using System;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Roundalize
{
    class Program
    {
        /// <summary>
        /// Reads a file as lines, returning it as an array of strings.
        /// </summary>
        /// <param name="filename">The filename of the file to read.</param>
        /// <returns></returns>
        private static string[] ReadFileAsLines(string filename)
        {
            return File.ReadAllText(filename)
                .Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)
                .Select(x => x.Trim())
                .ToArray();
        }

        static void Main(string[] args)
        {
            // Check file was specified.
            var precision = 5;
            if (args.Length != 2 || !int.TryParse(args[1], precision))
            {
                Console.WriteLine("Usage: Roundalize <file> <precision>");
                return;
            }

            // Check file exists.
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Could not read input file.");
                return;
            }

            // Read all entries.
            var entries = ReadFileAsLines(args[0]);

            // For each row.
            foreach (var entry in entries)
            {
                // Split into columns, we should have 3.
                var cols = entry.Split(':');
                if (cols.Length != 3)
                {
                    continue;
                }

                // Grab numerator and denominator.
                var numerator = new BigDecimal(BigInteger.Parse(cols[1]), 0);
                var denominator = new BigDecimal(BigInteger.Parse(cols[2]), 0);

                // Relay output to user.
                Console.WriteLine($"{cols[0]}={(decimal)(numerator / denominator).Truncate(precision)}");
            }
        }
    }
}
