using Microsoft.EntityFrameworkCore;
using NajotTalim.HR.DataAcces.Entities;
using NajotTalim.HR.DataAccess;
using System.Runtime.InteropServices;

namespace NajotTalim.HR.DataAcces
{
    public class EmployeeRepository : IEmployeeRepasitory
    {
        private readonly AppDbContext _dbContext;
        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }


        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
           return await _dbContext.Employees.ToListAsync(); 
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var updatedEmployee=_dbContext.Employees.Attach(employee);
            updatedEmployee.State= EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return employee;
        }
    }
}
