using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CalculateInterestApp
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            LinkedList<Person> people = new LinkedList<Person>();
            people.AddFirst(new Person { Id = 1, Interest = 0, Name = "Mercy", PrincipalAmount = 10000 });
            people.AddFirst(new Person { Id = 2, Interest = 0, Name = "Terry", PrincipalAmount = 12000 });
            people.AddFirst(new Person { Id = 3, Interest = 0, Name = "Angie", PrincipalAmount = 13000 });
            people.AddFirst(new Person { Id = 4, Interest = 0, Name = "Lydia", PrincipalAmount = 14000 });
            people.AddFirst(new Person { Id = 5, Interest = 0, Name = "Mitchelle", PrincipalAmount = 15000 });
            people.AddFirst(new Person { Id = 6, Interest = 0, Name = "BarBara", PrincipalAmount = 16000 });
            people.AddFirst(new Person { Id = 7, Interest = 0, Name = "Tracy", PrincipalAmount = 17000 });
            people.AddFirst(new Person { Id = 8, Interest = 0, Name = "Natasha", PrincipalAmount = 18000 });
            people.AddFirst(new Person { Id = 9, Interest = 0, Name = "Janet", PrincipalAmount = 19000 });
            people.AddFirst(new Person { Id = 10, Interest = 0, Name = "Winne", PrincipalAmount = 20000 });

            CalculateInterest(people, 12.0);
            CalculateInterest(people, 15.0);
            CalculateInterest(people, 14.0);


            return new OkObjectResult(people);
        }

        public static void CalculateInterest(LinkedList<Person> people, double rate)
        {

            for (int i = 11; i >= 1; i--)
            {
                double index = 1 + rate / 100;
                index = Math.Pow(index, (double)i / 12) - 1;

                foreach (Person p in people)
                {
                    p.Interest = p.Interest + (index * p.PrincipalAmount);
                }

            }

        }


    }

    public class Person
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public double PrincipalAmount { get; set; }

        public double Interest { get; set; }
    }
}



