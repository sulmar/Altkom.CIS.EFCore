using System;

namespace Altkom.CIS.EFCore.Models
{
    public class Customer : Base
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Birthday { get; set; }
    }
}
