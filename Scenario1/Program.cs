using System;
using System.Text.Json;

namespace Scenario1
{
    class Program
    {
        static void Main(string[] args)
        {
            string employee = GetEmployee();
            Console.WriteLine(employee);

            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        /* TODO: 
         1) Programmatically create the JSON tree structure, also known as the
            Document Object Model (DOM), for the following JSON text.
            DO NOT use parsing or serialization.

            {
                "name": "John Smith",
                "is manager": true, 
                "employee ids": [ 1234, 54678, 90 ],
                "direct supervisor" : null,
                "address": 
                {
                    "address line 1": "One Microsoft Way",
                    "zip code": 98052
                }
            }

         2) Convert the DOM representation to its JSON text and return that. */
        private static string GetEmployee()
        {
            // TODO: Add/modify code here
            throw new NotImplementedException();
        }
    }
}
