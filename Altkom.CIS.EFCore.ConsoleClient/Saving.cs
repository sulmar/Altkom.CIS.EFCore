using Altkom.CIS.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altkom.CIS.EFCore.ConsoleClient
{
    class Saving
    {
        public static void Test()
        {
            AddTest();
            UpdateTest();
        }


        private static void AddTest()
        {
            var product = new Product
            {
                Color = "Black",
                Name = "Mouse",
                UnitPrice = 59.99m
            };

            using (var context = new MyContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        private static void UpdateTest()
        {
            using (var context = new MyContext())
            {
                var product = context.Products.Find(9);
                Console.WriteLine($"State {context.Entry(product).State}");

                product.UnitPrice = product.UnitPrice + 1; // zmiana ceny

                Console.WriteLine($"original unitprice: {context.Entry(product).OriginalValues["UnitPrice"]}");

                Console.WriteLine($"State {context.Entry(product).State}");

                context.SaveChanges();
                Console.WriteLine($"State {context.Entry(product).State}");
            }
        }


        private static void RemoveTest()
        {
            using (var context = new MyContext())
            {
                var product = context.Products.First();
                context.Products.Remove(product);
                // context.Entry(product).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
