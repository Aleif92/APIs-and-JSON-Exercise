using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class RonVSKanyeAPI
    {

        public static void Convo()
        {
            var client = new HttpClient();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Kanye says:\n {GetKenyeQoute(client)}\n");
                Thread.Sleep(2000);
                Console.WriteLine($"Ron says:\n{GetRonQuote(client)}\n");
            }
        }

        private static string GetKenyeQoute(HttpClient client)
        {
            
            var KanyeResponse = client.GetStringAsync("https://api.kanye.rest/").Result;

            return JObject.Parse(KanyeResponse).GetValue("quote").ToString();
        }

        private static string GetRonQuote(HttpClient client)
        {
            var RonResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
            return RonResponse.Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();
        }




    }
}
