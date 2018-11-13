using Altkom.CIS.EFCore.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CIS.EFCore.SampleData.Fakers
{
    class OrderDetailFaker : Faker<OrderDetail>
    {
        public OrderDetailFaker(IList<Item> items)
        {
            StrictMode(true);
            Ignore(p => p.Id);
            RuleFor(p => p.Item, f => f.PickRandom(items));
            RuleFor(p => p.Quantity, f => f.Random.Number(1, 10));
            RuleFor(p => p.UnitPrice, (f, d) => d.Item.UnitPrice);
            FinishWith((f, d) => Console.WriteLine($"Created detail {d.Item.Name} {d.Quantity} {d.UnitPrice}"));
        }
    }
}
