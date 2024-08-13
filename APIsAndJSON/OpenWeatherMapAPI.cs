using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        //https://api.openweathermap.org/data/2.5/weather?zip=55374&appid=1fa22226a62c7c27875ba273b030168d&units=imperial
        
        public static void GetTemp()
        {
            //Grabbing the appsettings file test
            var appsettingsText = File.ReadAllText("appsettings.json");
        
            //Turn the json into an object to grab the piece I need (api key)
            var apiKey = JObject.Parse(appsettingsText).GetValue("key").ToString();
            //Ask user for there Zip
            Console.WriteLine("Enter Zip Code:");
            //Enter the zip code to provide for the url
            var zip = Console.ReadLine();
            
            //buil the url from the api call comes from 
            var url = $"https://api.openweathermap.org/data/2.5/weather?zip={zip}&appid={apiKey}&units=imperial";
            
            //Create an HTTPClient instance to make the api call
            var client = new HttpClient();

            var jsonText = client.GetStringAsync(url).Result;
            
            //Parse the string as a json Object - this obj can be indexed like an array
            var weatherObj = JObject.Parse(jsonText);
            
            //Print the info we need using the weaterh obj
            Console.WriteLine($"Temp: {weatherObj["main"]["temp"]}");
        }
    }
    
    
}
