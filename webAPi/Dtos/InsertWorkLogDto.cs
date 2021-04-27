using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webAPi.Dtos
{
    public class InsertWorkLogDto
    {
        public int Id { get; set; }
       [Required]
        public int EmployeeId { get; set; }
        public int WorkHoursOrDays { get; set; }
        public DateTime Date { get; set; }

    }
}
