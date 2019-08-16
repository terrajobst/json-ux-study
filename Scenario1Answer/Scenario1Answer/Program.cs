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
        }

        /* TODO: 
         1) Create an in-memory writable JSON DOM that represents the following JSON:
             {
                 "first name": "John",
                 "last name": "Smith",
                 "age": 45,
                 "is manager": true, 
                 "reporting FTE employees ids": [ 1234, 54678, 90, 123, 56789 ],
                 "reporting intern employees ids" : [],
                 "direct supervisor" : null,
                 "phone numbers": ["123-456-7890", "098-765-4321"],
                 "addresses": 
                  {
                     "office":
                     {
                         "address line 1": "One Microsoft Way",
                         "city": "Redmond",
                         "zip code": 98052,
                         "state": "WA"
                     },
                     "home":
                     {
                         "address line 1": "Pear Ave",
                         "address line 2": "1288",
                         "city": "Mountain View",
                         "zip code": 94043,
                         "state": "CA"
                     }
                 }
             }
         2) Return it as a string.
        */
        private static string GetEmployee()
        {
            var employee = new JsonObject()
            {
                { "first name", "John" },
                { "last name", "Smith" },
                { "age", 45 },
                { "is manager", true },
                { "reporting FTE employees ids", new JsonNumber[] {1234, 54678, 90, 123, 56789 } },
                {  "reporting intern employees ids", (JsonNode) new JsonArray() },
                {  "direct supervisor", (JsonNode) null },
                {  "phone numbers", new JsonString[] { "123-456-7890", "098-765-4321" } },
                {
                    "addresses", new JsonObject()
                    {
                        {
                            "office", new JsonObject()
                            {
                                {  "address line 1", "One Microsoft Way" },
                                {  "city" , "Redmond" } ,
                                {  "zip code" , 98052 } ,
                                {  "state" , "WA" }
                            }
                        },
                        {
                            "home", new JsonObject()
                            {
                                {  "address line 1", "Pear Ave" },
                                {  "address line 2", "1288" },
                                {  "city" , "Mountain View" } ,
                                {  "zip code" , 94043 } ,
                                {  "state" , "CA" }
                            }
                        }
                    }
               }
             };
            
            return employee.ToString();
        }
    }
}
