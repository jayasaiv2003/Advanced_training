using Employee_Management.Data.Repository;
using Employee_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class Employee_App : ControllerBase
    {
        public readonly IEmployeeRepository _employeeRepository;
        public Employee_App(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        [Route("GetAllEmployees")]
        
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return Ok(employees);
        }
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        [Route("AddEmployee")]
        [AllowAnonymous]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            await _employeeRepository.AddAsync(employee);
            return Ok(employee);
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            var existing = await _employeeRepository.GetByIdAsync(employee.EmployeeId);
            if (existing == null)
            {
                return NotFound();
            }
            await _employeeRepository.UpdateAsync(employee);
            return Ok(employee);
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var exisiting = await _employeeRepository.GetByIdAsync(id);
            if (exisiting == null)
            {
                return NotFound();
            }
            await _employeeRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
