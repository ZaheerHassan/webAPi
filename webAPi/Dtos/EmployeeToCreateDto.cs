using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPi.Model;

namespace webAPi.Dtos
{
    public class EmployeeToCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public decimal PayRate { get; set; }
        public string Designation { get; set; }
    }
}
