using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPi.Model
{
    public enum EmployeeType {
    OffShore,
    OnShore,
    DailyWages
    }
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public decimal PayRate { get; set; }
        public string Designation { get; set; }
        public Boolean Active { get; set; }
    }
}
