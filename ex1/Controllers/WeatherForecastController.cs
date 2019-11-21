using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ex1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetFiveRandomNumbers")]

        public List<int> GetFiveRandomNumbers()

        {

            var numbers = new List<int>();

            var rnd = new Random();

            int count = 0;

            while (count < 5)
            {

                int newNum = rnd.Next(1, 21); // generate a random number between 1- 20

                if (!numbers.Contains(newNum))
                {

                    numbers.Add(newNum);

                    count++;

                }

            }

            return numbers;

        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetOddwords")]
        public string GetOddwords(string txt) 
        {
            if (txt == null)
                return "txt is missing";

            string[] words = txt.Split(" ");
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < words.Count(); i++)
            {
                if (i % 2 == 0)
                    sb.Append(words[i]+ " ");

            }
            
            return sb.ToString();
               
        }

        [HttpGet("GetFourDigits")]
        public int[] GetFourDigits(int num) 
        {
            if (num < 1000 || num > 9999)
            {
                
                return new int[0];
            }
            int[] arr= new int[4];

            for (int i = 0; i < 4; i++)
            {
               
                arr[i] = num%10;
                num/= 10;

            }
            return arr;
        }

        [HttpGet("UniteTwoStrings")]
        public string UniteTwoStrings(string txt1, string txt2)
        {
            if (txt1 == null || txt2 ==null)
                return "at least 1 string is missing";

            StringBuilder sb = new StringBuilder();

            sb.Append(txt1 + " " + txt2);

            return sb.ToString();


        }
        
        [HttpGet("GetMaxOutOfThree")]
        public int GetMaxOutOfThree(int num1, int num2, int num3)
        {

            return Math.Max(num1, Math.Max(num2, num3));

        }

        [HttpGet("GetAllNumBelow")]
        public int[] GetAllNumBelow(int num)
        {
            int[] arr = new int[num];

            while (num > 0)
            {
                arr[--num] = num;
            }
                return arr;
            
        }
    }

}
