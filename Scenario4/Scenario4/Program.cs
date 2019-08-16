using System;
using System.IO;
using System.Text.Json;

namespace Scenario4
{
    class Program
    {
        static void Main(string[] args)
        {
            string configuration = ParseFile("config.json");
            JsonNode modifiableConfiguration = GetModifiableConfiguration(configuration);
            Console.WriteLine(modifiableConfiguration);
        }

        // TODO: The following method returns caching property set to "true" (first occurance value). Make it return the last occurance value.
        private static JsonNode GetModifiableConfiguration(string configuration)
        {
            return JsonNode.Parse(configuration); 
        }

        private static string ParseFile(string fileName)
        {
            string dir = Directory.GetCurrentDirectory();

            string fullPath = dir + "\\" + fileName;

            int count = 0;
            while (true)
            {
                if (count > 5)
                {
                    throw new FileNotFoundException($"The file necessary for this scenario could not be found. Looking for {fileName}.");
                }
                if (File.Exists(fullPath))
                {
                    break;
                }
                if (dir.EndsWith("Scenario3\\"))
                {
                    throw new FileNotFoundException($"The file necessary for this scenario could not be found (stopped searching at project root). Looking for {fileName}.");
                }
                dir = Path.GetFullPath(Path.Combine(dir, @"..\"));
                fullPath = dir + "\\" + fileName;
                count++;
            }

            return File.ReadAllText(fullPath);
        }
    }
}
}
