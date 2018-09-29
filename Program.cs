using DialogueWise.Client;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace DialogueWiseDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of wheels");
            var input = Console.ReadLine();

            int.TryParse(input, out var wheels);

            var request = new DialogueWiseRequest()
            {
                ApiKey = "b1266377591c4f2a9494c3abdd2cac5381D6Z825D26CEBAE8B6rn",
                DialogueName = "demo-dialogue",
                EmailHash = "/kgmM46s1xC56BOFWRZp4j+0bdU19URpXdNT9liAX50=",
                VariableList = new Dictionary<string, object>()
                {
                    {"@wheel",wheels}
                }
            };

            var dialogueWise = new DialogueWiseClient();
            var response = dialogueWise.GetDialogue(request);
            var jObject = JObject.Parse(response.Result);
            var content = jObject["dialogue"];

            Console.WriteLine(content);
            Console.ReadLine();
        }
    }
}
