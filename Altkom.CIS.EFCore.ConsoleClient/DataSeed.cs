using Altkom.CIS.EFCore.Models;
using Altkom.CIS.EFCore.SampleData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Altkom.CIS.EFCore.ConsoleClient
{
    class DataSeed
    {
        public static void Test()
        {
            var customers = Generator.GetCustomers(100);
            var products = Generator.GetProducts(50);
            var services = Generator.GetServices(20);

            var order = new Order
            {
                OrderNumber = "ZA 001/2018",
                Customer = customers.First(),
                DeliveryDate = DateTime.Now.AddDays(5),
                Details = new List<OrderDetail>
                {
                    new OrderDetail(products.First(), 5),
                    new OrderDetail(services.First())
                }
            };

            using (MyContext context = new MyContext())
            {
                context.Customers.AddRange(customers);
                context.Products.AddRange(products);
                context.Services.AddRange(services);
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
    }
}
