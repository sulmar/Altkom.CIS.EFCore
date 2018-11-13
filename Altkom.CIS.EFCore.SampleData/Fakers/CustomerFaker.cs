using Altkom.CIS.EFCore.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CIS.EFCore.SampleData.Fakers
{
    class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
            StrictMode(true);
            Ignore(p => p.Id);
            RuleFor(p => p.FirstName, f => f.Name.FirstName());
            RuleFor(p => p.LastName, f => f.Name.LastName());
            RuleFor(p => p.Email, f => f.Internet.Email());
            RuleFor(p => p.IsDeleted, f => f.Random.Bool(0.8f));
            FinishWith((f, customer) 
                => Console.WriteLine($"Created {customer.FirstName} {customer.LastName} {customer.Email}"));

        }
    }
}
