using System;
using System.IO;
using System.Text.Json;

namespace Scenario2
{
    class Program
    {
        static void Main(string[] args)
        {
            string configuration = File.ReadAllText("config.json");
            string doubledProperties = DoubleAllProperties(configuration);
            Console.WriteLine(doubledProperties);
        }

        /* TODO: Return a string containing properties from a given config file with following modifications:
         1) Multiply all values by 2.
         2) Insert a property "input_frequency" with value 6.
         Make sure you take the numeric values of properties.*/
        private static string DoubleAllProperties(string configuration)
        {
            throw new NotImplementedException();
        }
    }
}
