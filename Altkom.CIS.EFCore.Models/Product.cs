using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.CIS.EFCore.Models
{
    public class Product : Item
    {
        public string Color { get; set; }
        public string Size { get; set; }
    }

    public class Service : Item
    {
        public TimeSpan Duration { get; set; }
    }

    public abstract class Item : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
