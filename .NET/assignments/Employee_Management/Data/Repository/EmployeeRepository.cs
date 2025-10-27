using Employee_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly EmployeeDbContext _dbcontext;

        public EmployeeRepository(EmployeeDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task AddAsync(Employee employee)
        {
            await _dbcontext.Employees.AddAsync(employee);
            await  _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee =  await _dbcontext.Employees.FindAsync(id);
            if (employee != null)
            {
                _dbcontext.Employees.Remove(employee);
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dbcontext.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _dbcontext.Employees.FindAsync(id);
        }

        public async Task UpdateAsync(Employee employee)
        {
            var existingEmployee = await _dbcontext.Employees.FindAsync(employee.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.FullName = employee.FullName;
                existingEmployee.Department = employee.Department;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.Email = employee.Email;
                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}
