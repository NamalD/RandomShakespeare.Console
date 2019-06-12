using System;
using ShakespeareGenerator;

namespace ConsoleDisplay
{
    class Program
    {
        static void Main()
        {
            // Download and extract text from poems
            var scraper = new PoemScraper();

            Console.WriteLine("Retrieving poems");
            var corpus = scraper.GetPoemsAsync().Result;

            // Generate
            var generator = new Generator(corpus);

            while (true)
            {
                Console.Clear();
                Console.ResetColor();

                // Generate and display poem
                var sonnet = generator.NextSonnet();

                foreach (var line in sonnet)
                {
                    Console.WriteLine(line);
                }

                // Restart if requested
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{Environment.NewLine}Press Enter to restart");
                var response = Console.ReadKey();

                if (response.Key != ConsoleKey.Enter)
                {
                    return;
                }
            }
        }
    }
}
