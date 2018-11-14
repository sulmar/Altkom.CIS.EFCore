using Altkom.CIS.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altkom.CIS.EFCore.ConsoleClient
{
    class Querying
    {

        public static void Test()
        {
            GetActiveCustomersTest();
            GroupByTest();
        }

        private static void GetActiveCustomersTestNoLinq()
        {
            using (var context = new MyContext())
            {
                var customers = context.Customers.ToList();

                List<Customer> results = new List<Customer>();

                foreach (Customer customer in customers)
                {
                    if (!customer.IsDeleted)
                    {
                        results.Add(customer);
                    }
                }
            }
        }


        // select customerId, count(*) 
        //      from orders
        //        group by customerId

        // customerid | qty

        // select * from Customers where IsDeleted = 0 order by FirstName, LastName



        private static void GroupByTest()
        {
            using (var context = new MyContext())
            {
                var query = context.Customers.GroupBy(c => c.IsDeleted)
                    .Select(g => new { IsDeleted = g.Key, Count = g.Count() })
                    .ToList();
            }

            using (var context = new MyContext())
            {
                var query2 = context.Orders
                    .GroupBy(c => c.Customer.Id)
                    .Select(g => new { CustomerId = g.Key, OrderCount = g.Count() })
                    .ToList();
            }
        }


        private static void GetActiveCustomersTest()
        {
            using (var context = new MyContext())
            {
                IQueryable<Customer> query = context.Customers                    
                    .Where(c => !c.IsDeleted)
                    .OrderBy(c => c.FirstName)
                    .ThenBy(c => c.LastName);

                // query = query.Where(c => c.Id > 100);

                List<Customer> customers = query.ToList();

                Display(customers);
            }
        }

        private static void Display(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName} {customer.IsDeleted}");
            }
        }
    }
}
