using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPi.Model;

namespace webAPi.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base (options)
        {

        }
     
        public DbSet<User> Users { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<WorkLog> WorkLogs { get; set; }
        public DbSet<payroll> payrolls { get; set; }

        public DbSet<payrollDetail> payrollDetails { get; set; }

    }
}
