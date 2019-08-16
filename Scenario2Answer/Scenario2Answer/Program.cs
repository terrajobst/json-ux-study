using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Scenario2
{
    class Program
    {
        static void Main(string[] args)
        {
            string configuration = ParseFile("config.json");
            string doubledProperties = DoubleAllProperties(configuration);
            Console.WriteLine(doubledProperties);
        }

        /* TODO: Return a string containing properties from a given config file with following modifications:
         1) Multiply all values by 2.
         2) Insert a property "input_frequency" with value 6 */
        private static string DoubleAllProperties(string configuration)
        {
            //var configurationObject = JsonNode.Parse(configuration);
            var configurationObject = new JsonObject()
            {
                { "domain_size", 2 },
                { "echo_level", 0 },
                { "displacement_relative_tolerance", 0.0001 },
                { "displacement_absolute_tolerance", 1e-9 },
                { "output_frequency", 4 },
                { "factor", 9.8 },
            };

            foreach(KeyValuePair<string, JsonNode> property in configurationObject)
            {
                var jsonNumber = property.Value as JsonNumber;
                if(jsonNumber.TryGetInt32(out int integerNumber))
                {
                    jsonNumber.SetInt32(integerNumber * 2);
                }
                else
                {
                    jsonNumber.TryGetDouble(out double doubleNumber);
                    jsonNumber.SetDouble(doubleNumber * 2);
                }
            }

            configurationObject.Add("input_frequency", 6);

            return configurationObject.ToString();
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
