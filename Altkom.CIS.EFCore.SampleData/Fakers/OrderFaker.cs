using Altkom.CIS.EFCore.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CIS.EFCore.SampleData.Fakers
{
    class OrderFaker : Faker<Order>
    {
        public OrderFaker(IList<Customer> customers, OrderDetailFaker orderDetailFaker)
        {
            StrictMode(true);
            Ignore(p => p.Id);
            RuleFor(p => p.OrderNumber, f => f.Random.Replace("###-###-###"));
            RuleFor(p => p.OrderDate, f => f.Date.Past(3));
            RuleFor(p => p.Customer, f => f.PickRandom(customers));
            RuleFor(p => p.Details, f => orderDetailFaker.Generate(f.Random.Number(1, 5)));
            RuleFor(p => p.DeliveryDate, (f, order) => order.OrderDate.AddDays(f.Random.Number(2, 14)));
            FinishWith((f, order) => Console.WriteLine($"Created order {order.OrderNumber}"));

        }
    }
}
