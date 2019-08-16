﻿using System;
using System.Text.Json;

namespace Scenario3
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonElement student = GetStudent();
            student = ModifyStudent(student);
        }

        /* TODO: 
         1) Modify the given JsonElement by:
            * changing e-mail property to "annp@mail.com"
            * adding a grade 77.89 between 89.5 and 56.0 in the grades array.
         2) Return back JsonElement object.*/    
        private static JsonElement ModifyStudent(JsonElement student)
        {
            throw new NotImplementedException();
        }

        private static JsonElement GetStudent()
        {
            string jsonString = @"
            {
                ""first name"" : ""Ann"",
                ""last name"" : ""Predictable"",
                ""email"" : ""ann.predictable@mail.com"",
                ""grades"": [73.21, 89.5, 56.0],
            }";
            
            JsonDocument document = JsonDocument.Parse(jsonString);
            return document.RootElement;
        }
    }
}