using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NajotTalim.HR.DataAcces.Services
{
    public class EmployeeCRUDService : IGenericCRUDService<EmployeeModel>
    {
        private readonly IEmployeeRepasitory _employeeRepasitory;
        public EmployeeCRUDService(IEmployeeRepasitory employeeRepasitory)
        {
            _employeeRepasitory = employeeRepasitory;     
        }
        public async Task<EmployeeModel> Create(EmployeeModel model)
        {
            var employee = new Employee
            {
                Name = model.Name,
                Department = model.Department,
                Email = model.Email,
               
            };
            var createdEmployee= await _employeeRepasitory.CreateEmployee(employee);
            var result = new EmployeeModel
            {
                Name = createdEmployee.Name,
                Department = createdEmployee.Department,
                Email = createdEmployee.Email,
                Id = createdEmployee.Id

            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
           return await _employeeRepasitory.DeleteEmployee(id);
        }

        public async Task<EmployeeModel> Get(int id)
        {
            var employee=await _employeeRepasitory.GetEmployee(id);
            var model = new EmployeeModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department,
                Email = employee.Email,
            };
            return model;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            var result = new List<EmployeeModel>();
            var employees = await _employeeRepasitory.GetEmployees();
            foreach (var employee in employees)
            {
                var model = new EmployeeModel
                {
                  
                    Name = employee.Name,
                    Department = employee.Department,
                    Email = employee.Email,
                    Id = employee.Id
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<EmployeeModel> Update(int id, EmployeeModel model)
        {
            var employee = new Employee
            {
                Name = model.Name,
                Department = model.Department,
                Email = model.Email,

            };
            var updatedEmployee = await _employeeRepasitory.UpdateEmployee(id,employee);
            var result = new EmployeeModel
            {
                Name = updatedEmployee.Name,
                Department = updatedEmployee.Department,
                Email = updatedEmployee.Email,
                Id = updatedEmployee.Id

            };
            return result;
        }
    }
}
