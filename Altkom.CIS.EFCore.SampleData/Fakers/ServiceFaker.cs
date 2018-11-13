using Altkom.CIS.EFCore.Models;
using Bogus;
using System;

namespace Altkom.CIS.EFCore.SampleData.Fakers
{
    public class ServiceFaker : Faker<Service>
    {
        public ServiceFaker()
        {
            StrictMode(true);
            Ignore(p => p.Id);
            RuleFor(p => p.Name, f => f.Commerce.ProductAdjective());
            RuleFor(p => p.UnitPrice, f => decimal.Parse(f.Commerce.Price()));
            RuleFor(p => p.Duration, f => f.Date.Timespan(TimeSpan.FromHours(3)));
            FinishWith((f, p) => Console.WriteLine($"Created service {p.Name}"));
        }
    }
}
