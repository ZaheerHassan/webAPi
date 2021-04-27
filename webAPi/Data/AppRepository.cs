using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPi.Helpers;
using webAPi.Model;

namespace webAPi.Data
{
    public class AppRepository : IAppRepository
    {
        private readonly DataContext _dataContext;

        public AppRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
         void IAppRepository.Add<T>(T entity)
        {
            _dataContext.Add(entity);
        }

        void IAppRepository.Delete<T>(T entity)
        {
            _dataContext.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            return await user;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = _dataContext.Employees.ToListAsync();
            return await employees;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var user = _dataContext.Employees.FirstOrDefaultAsync(u => u.Id == id);
            return await user;
        } 

        async Task<bool> IAppRepository.SaveAll()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<object>> GetWorkLogs()
        {
            var result = await (from w in _dataContext.WorkLogs
                          join e in _dataContext.Employees on w.EmployeeId equals e.Id
                          select new
                          {
                              w.Id,
                              w.Date,
                              w.EmployeeId,
                              e.FirstName,
                              e.EmployeeType
        }).ToListAsync();
            return result;
           
        }

        public async Task<List<WorkLog>> GetEmployeeWorkLogs(int EmployeeID)
        {
           var worklog =  await _dataContext.WorkLogs.Where(u => u.EmployeeId == EmployeeID).ToListAsync();
            return worklog;
        }

        public async Task<WorkLog> GetWorkLogbyID(int ID)
        {
            var worklog = await _dataContext.WorkLogs.FirstOrDefaultAsync(u => u.Id == ID);
            return worklog;
        }

    
    }
}
