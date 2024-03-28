using NajotTalim.HR.DataAcces.Entities;
using NajotTalim.HR.DataAcces;
using WebApplication1.Models;

namespace NajotTalim.HR.DataAcces.Services
{
    public class EmployeeCRUDService : IGenericCRUDService<EmployeeModel>
    {
        private readonly IEmployeeRepasitory _employeeRepasitory;
        private readonly IAddressRepository _addressRepository;
        public EmployeeCRUDService(IEmployeeRepasitory employeeRepasitory, IAddressRepository addressRepository)
        {
            _employeeRepasitory = employeeRepasitory;
            _addressRepository = addressRepository;
        }
        public async Task<EmployeeModel> Create(EmployeeModel model)
        {
            var existingAddress = await _addressRepository.GetAddress(model.AddressId);
            var employee = new Employee
            {
                Name = model.Name,
                Department = model.Department,
                Email = model.Email


            };
            if (existingAddress != null) 
                employee.Address = existingAddress;

            var createdEmployee = await _employeeRepasitory.CreateEmployee(employee);
            var result = new EmployeeModel
            {
                Name = createdEmployee.Name,
                Department = createdEmployee.Department,
                Email = createdEmployee.Email,
                Id = createdEmployee.Id,
                AddressId= model.AddressId,
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _employeeRepasitory.DeleteEmployee(id);
        }

        public async Task<EmployeeModel> Get(int id)
        {
            var employee = await _employeeRepasitory.GetEmployee(id);
            var model = new EmployeeModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department,
                Email = employee.Email
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
                Id = model.Id

            };
            var updatedEmployee = await _employeeRepasitory.UpdateEmployee(id, employee);
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

  
