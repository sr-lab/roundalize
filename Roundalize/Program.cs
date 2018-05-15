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
            // Print usage if no arguments provided.
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: Roundalize <file> [precision]");
                return;
            }

            // Check file exists.
            var path = args[0];
            if (!File.Exists(path))
            {
                Console.WriteLine($"Could not read input file '{path}'.");
                return;
            }

            // Try to parse precision option.
            var precision = 5;
            if (args.Length == 2)
            {
                if (!int.TryParse(args[1], out precision))
                {
                    Console.WriteLine($"Could not parse '{args[1]}' as number. Using default precision {precision} instead.");
                }
            }

            // Read all entries.
            var entries = ReadFileAsLines(path);

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
