using Altkom.CIS.EFCore.Models;
using Altkom.CIS.EFCore.SampleData.Fakers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.CIS.EFCore.SampleData
{
    public class Generator
    {
        public static IEnumerable<Customer> GetCustomers(int count)
        {
            var customerFaker = new CustomerFaker();
            var customers = customerFaker.Generate(count);
            return customers;
        }


        public static IEnumerable<Product> GetProducts(int count)
        {
            var productFaker = new ProductFaker();
            return productFaker.Generate(count);
        }

        public static IEnumerable<Service> GetServices(int count)
        {
            var serviceFaker = new ServiceFaker();
            return serviceFaker.Generate(count);
        }

        public static IEnumerable<Order> GetOrders(int count)
        {
            var customers = GetCustomers(100).ToList();

            var products = GetProducts(50);
            var services = GetServices(20);

            IList<Item> items = products.Cast<Item>().Concat(services).ToList();

            var orderFaker = new OrderFaker(customers, new OrderDetailFaker(items));

            return orderFaker.Generate(count);
        }
    }
}
