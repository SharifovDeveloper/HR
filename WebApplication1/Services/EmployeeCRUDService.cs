using NajotTalim.HR.DataAcces.Entities;
using NajotTalim.HR.DataAcces;
using WebApplication1.Models;

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
                Email = model.Email


            };
            var createdEmployee = await _employeeRepasitory.CreateEmployee(employee);
            var result = new AddressModel
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

        public async Task<AddressModel> Get(int id)
        {
            var employee = await _employeeRepasitory.GetEmployee(id);
            var model = new AddressModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department,
                Email = employee.Email
            };
            return model;
        }

        public async Task<IEnumerable<AddressModel>> GetAll()
        {
            var result = new List<AddressModel>();
            var employees = await _employeeRepasitory.GetEmployees();
            foreach (var employee in employees)
            {
                var model = new AddressModel
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

        public async Task<AddressModel> Update(int id, AddressModel model)
        {
            var employee = new Employee
            {
                Name = model.Name,
                Department = model.Department,
                Email = model.Email,
                Id=model.Id

            };
            var updatedEmployee = await _employeeRepasitory.UpdateEmployee(id, employee);
            var result = new AddressModel
            {
                Name = updatedEmployee.Name,
                Department = updatedEmployee.Department,
                Email = updatedEmployee.Email,
                Id = updatedEmployee.Id

            };
            return result;
        }
    }

  
