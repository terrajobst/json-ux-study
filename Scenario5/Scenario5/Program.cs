using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Scenario5
{
    class Program
    {
        // Do not modify this method.
        static void Main(string[] args)
        {
            // Task 1
            Account johnAccount = GetAccount();
            Console.WriteLine(SerializeToCustomJson(johnAccount));

            // Task 2
            string customJson = GetCustomFormattedAccountJson();
            Account jetAccount = DeserializeFromCustomJson(customJson);
            Console.WriteLine(jetAccount?.Email);
            Console.WriteLine(jetAccount?.CreatedDate);

            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
        }

        // The Example Company uses the MM/dd/yy format for DateTime values in their Account models.
        // TODO: 1) Serialize the "account" object to a custom-formatted JSON string and return it.
        private static string SerializeToCustomJson(Account account)
        {
            // <Add/modify code here>
            return "";
        }

        // The Example Company uses the MM/dd/yy format for DateTime values in their Account models.
        // TODO: 2) Deserialize the custom-formatted JSON string as an "account" object and return it.
        private static Account DeserializeFromCustomJson(string json)
        {
            // <Add/modify code here>
            return null;
        }

        private static Account GetAccount()
        {
            // Note: Do NOT modify the Account object creation.
            Account account = new Account
            {
                Email = "john@example.com",
                CreatedDate = DateTime.Parse("08/16/2019")
            };

            return account;
        }

        private static string GetCustomFormattedAccountJson()
        {
            // Note: Do NOT modify the Account JSON representation.
            string json = @"{
                ""Email"": ""jet@example.com"",
                ""CreatedDate"": ""08/18/2019""
            }";
            return json;
        }
    }

    public class Account
    {
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    // Alternate solution is to create a custom converter for the Account object.

    public class ExampleDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));
            return DateTime.ParseExact(reader.GetString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("MM/dd/yyyy"));
        }
    }
}
