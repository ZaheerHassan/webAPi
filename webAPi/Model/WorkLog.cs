using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPi.Model
{
    public class WorkLog
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int WorkHoursOrDays { get; set; }
        public DateTime Date { get; set; }

    }
}
