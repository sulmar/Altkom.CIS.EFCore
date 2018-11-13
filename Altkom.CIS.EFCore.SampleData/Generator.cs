using Altkom.CIS.EFCore.Models;
using Altkom.CIS.EFCore.SampleData.Fakers;
using System;
using System.Collections;
using System.Collections.Generic;

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
    }
}
