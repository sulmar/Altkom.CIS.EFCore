using Altkom.CIS.EFCore.SampleData;
using System;

namespace Altkom.CIS.EFCore.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CreateDatabase.Test();
            //DataSeed.Test();

            DataSeed.CreateOrdersTest(1000);
            //Saving.Test();

            Querying.Test();

             

            // Display(customers);

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }

        private static void Display(System.Collections.Generic.IEnumerable<Models.Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}");
            }
        }
    }
}
