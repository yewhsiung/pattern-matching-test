using System;

namespace PatternMatchingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pattern Matching Test Console");

            while (true)
            {
                Console.WriteLine();
                Console.Write("Input (blank to exit): ");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                Console.Write("Pattern (blank to exit): ");
                var pattern = Console.ReadLine();

                if (string.IsNullOrEmpty(pattern))
                {
                    break;
                }

                Console.WriteLine("Result: {0}", PatternMatcher.IsMatch(input, pattern) ? "Matched" : "Not Matched");
            }

            Console.WriteLine("Bye");
            Console.Read();
        }
    }
}
