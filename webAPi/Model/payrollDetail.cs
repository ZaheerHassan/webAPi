using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPi.Model
{
    public class payrollDetail
    {
        public int Id { get; set; }
        public int PayrollId { get; set; }
        public int EmployeeID { get; set; }
        public decimal Amount { get; set; }
    }
}
