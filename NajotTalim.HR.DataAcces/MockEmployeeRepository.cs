using System.Collections.Concurrent;

namespace NajotTalim.HR.DataAcces
{
    public class MockEmployeeRepository:IEmployeeRepasitory
    {
        private static ConcurrentDictionary<int, Employee> _employees = new ConcurrentDictionary<int, Employee>();
        private readonly object locker;
        public MockEmployeeRepository()
        {
            Init();
        }

        public  void Init()
        {
            _employees.TryAdd(1, new Employee { Id = 1, Name = "Joe", Department = "IT", Email = " joe2@gmail.com" });
            _employees.TryAdd(2, new Employee { Id = 2, Name = "Jack", Department = "Salas", Email = " jack122@gmail.com" });
            _employees.TryAdd(3, new Employee { Id = 3, Name = "David", Department = "HR", Email = " David21@gmail.com" });
            _employees.TryAdd(4, new Employee { Id = 4, Name = "Salah", Department = "Markenting", Email = " Salah11@gmail.com" });
        }
        public async Task<Employee>CreateEmployee(Employee employee) 
        {
            int newId = 0;
            lock (locker)
            {
                newId = _employees.Keys.Max() + 1;
            }
            employee.Id=newId;
            _employees.TryAdd(newId, employee);
            return await Task.FromResult(employee);
            
        }
        public async Task< IEnumerable<Employee>> GetEmployees()
        {
            return await Task.FromResult(_employees.Values);
        }
        public async Task< Employee> GetEmployee(int id)
        {
            return await Task.FromResult(_employees[id]);
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            await Task.FromResult(_employees[id] = employee);
            return employee;
        }

        public Task<bool> DeleteEmployee(int id)
        {
            if (_employees.ContainsKey(id))
            {
                _employees.TryRemove(id, out _);
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);

            }
        }
    }
}
