using System.Collections.Generic;

namespace PracticeDapper.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCity { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
