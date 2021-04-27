using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPi.Helpers;
using webAPi.Model;

namespace webAPi.Data
{
   public interface IAppRepository
    {
        public void Add<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<User> GetUser(int id);
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<IEnumerable<object>> GetWorkLogs();
        Task<List<WorkLog>> GetEmployeeWorkLogs(int Employeeid);
        Task<WorkLog> GetWorkLogbyID(int id);
    }
}
