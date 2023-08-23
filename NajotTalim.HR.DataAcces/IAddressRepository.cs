﻿using NajotTalim.HR.DataAcces.Entities;

namespace NajotTalim.HR.DataAcces
{
    public interface IAddressRepository
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task <Employee> UpdateEmployee(int id, Employee employee);
        Task <bool> DeleteEmployee(int id);
    }
}