using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class EmployeesController : BaseApiController
    {
        private readonly IGenericRepository<Employee> _empRepo;
        private readonly IGenericRepository<Position> _positionRepo;
        private readonly IMapper _mapper;

        public EmployeesController(IGenericRepository<Employee> empRepo,
            IGenericRepository<Position> positionRepo,
            IMapper mapper)
        {
            _empRepo = empRepo;
            _positionRepo = positionRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EmployeeDto>>> GetEmployees(
            [FromQuery] SpecParams specParams)
        {
            var spec = new EmployeesWithRelatedDataAndFilters(specParams);
            IReadOnlyList<Employee> employees = await _empRepo.ListBySpecAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Employee>, IReadOnlyList<EmployeeDto>>(employees));
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var spec = new EmployeesWithRelatedDataAndFilters(id);
            var emp = await _empRepo.GetItemWithSpecAsync(spec);

            if (emp == null) return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<Employee, EmployeeDto>(emp));
        }

        [HttpPost("add")]
        public async Task<ActionResult<EmployeeDto>> AddEmployee([FromBody] AddEmployeeDto addEmp)
        {
            if (addEmp == null) return BadRequest(new ApiResponse(400));

            var pIdSpec = new EmployeeByPersonalIdSpecification(addEmp.PersonalId);
            var empByPersonalId = await _empRepo.GetItemWithSpecAsync(pIdSpec);

            if (empByPersonalId != null)
                return BadRequest(new ApiResponse(403,$"employee with personal id : {addEmp.PersonalId} already exists"));

            var numSpec = new EmployeeByPhoneNumberSpecification(addEmp.PhoneNumber);
            var empByNumber = await _empRepo.GetItemWithSpecAsync(numSpec);

            if (empByNumber != null)
                return BadRequest(new ApiResponse(403,$"employee with phone number: {addEmp.PhoneNumber} already exists "));


            var newEmployee = _mapper.Map<AddEmployeeDto, Employee>(addEmp);
            await _empRepo.AddAsync(newEmployee);

            return CreatedAtAction(
                nameof(GetEmployeeById),
                new {id = newEmployee.Id},
                _mapper.Map<Employee, EmployeeDto>(newEmployee)
            );
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateEmployee(int id,
            UpdateEmployeeDto updateEmployee)
        {
            var empToMatch = await _empRepo.GetByIdAsync(id);

            if (empToMatch == null) return NotFound(new ApiResponse(404));

            _mapper.Map(updateEmployee, empToMatch);
            await _empRepo.SaveChanges();

            return NoContent();
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _empRepo.GetByIdAsync(id);
            if (employee == null) return NotFound(new ApiResponse(404));

            await _empRepo.DeleteAsync(employee);
            return NoContent();
        }


        [AllowAnonymous]
        [HttpGet("personalIdExists")]
        public async Task<ActionResult<bool>> PersonalIdExists([FromQuery] string personalId)
        {
            var spec = new EmployeeByPersonalIdSpecification(personalId);
            var employeeWithPId = await _empRepo.GetItemWithSpecAsync(spec);

            return employeeWithPId != null;
        }


        [AllowAnonymous]
        [HttpGet("phoneExists")]
        public async Task<ActionResult<bool>> PhoneNumberExists([FromQuery] string number)
        {
            var spec = new EmployeeByPhoneNumberSpecification(number);
            var employeeWithPhoneNumber = await _empRepo.GetItemWithSpecAsync(spec);

            return employeeWithPhoneNumber != null;
        }

        [HttpGet("getPositions")]
        public async Task<ActionResult<IReadOnlyList<Position>>> GetPositions()
        {
            return Ok(await _positionRepo.ListAllAsync());
        }
    }
}