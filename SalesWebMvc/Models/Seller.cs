using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthdate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            Birthdate = birthdate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addSales(SalesRecord sales)
        {
            Sales.Add(sales);
        }

        public void removeSales(SalesRecord sales)
        {
            Sales.Remove(sales);
        }

        public double totalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(s => s.Date >= initial && s.Date <= final).Sum(s => s.Amount);
        }
    }
}
