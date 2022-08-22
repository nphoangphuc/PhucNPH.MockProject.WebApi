using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhucNPH.MockProject.Domain.Filters;
using PhucNPH.MockProject.Domain.Models;
using PhucNPH.MockProject.Domain.Ulitilities;
using PhucNPH.MockProject.Service.Mapper;
using PhucNPH.MockProject.Service.UOW;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PhucNPH.MockProject.Presentation.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [CustomExceptionFilter]
    [Route("employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeMapper _employeeMapper;
        private readonly IConfiguration _configuration;

        public EmployeeController(IUnitOfWork unitOfWork,
            IEmployeeMapper employeeMapper,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _employeeMapper = employeeMapper;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateEmployee(EmployeeCreateModel employeeCreateModel)
        {
            var employee = _employeeMapper.MapEmployeeCreateModelToEmployee(employeeCreateModel);
            employee = await _unitOfWork.EmployeeRepository.CreateAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return
                CreatedAtAction(nameof(GetEmployee),
                new { employeeId = employee.Id },
                _employeeMapper.MapEmployeeToEmployeeModel(employee));

        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            var employee = await _unitOfWork.EmployeeRepository.LoginAsync(loginModel);

            if (employee == null)
            {
                return Unauthorized(new ResponseResult(401, new List<string> { "Account/Password is wrong" }));
            }
            else
            {
                // List of username and email
                List<Claim> claims = new List<Claim>()
                    {
                        new Claim("userName",employee.Username),
                    };

                // Add user infomation to identity claim
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);

                // add key and encode key
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                #region JWT for server-side authentication
                // Create JWT for server-side authen
                var token = new JwtSecurityToken
                (
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claimsIdentity.Claims,
                    expires: DateTime.UtcNow.AddMinutes(20),
                    signingCredentials: signIn
                );

                // Convert JWT to string and return to client
                string strToken = new JwtSecurityTokenHandler().WriteToken(token);

                #endregion

                return Ok(new ResponseResult(200, strToken));
            }
        }

        [HttpGet]
        [Route("id/{employeeId}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployee(Guid employeeId)
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByEmployeeId(employeeId);

            var employeeModel = _employeeMapper.MapEmployeeToEmployeeModel(employee);
            if (employeeModel == null)
            {
                return NotFound(new ResponseResult(404, "This employee is not existed"));
            }

            return employeeModel;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeModel>>> GetEmployees()
        {
            var employees = await _unitOfWork.EmployeeRepository.GetMultipleEmployees();

            var employeeModels = employees.Select(employee => _employeeMapper.MapEmployeeToEmployeeModel(employee)).ToList();

            return employeeModels;
        }

        [HttpPut]
        [Route("id/{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(Guid employeeId, EmployeeUpdateModel employeeUpdateModel)
        {
            var currentEmployee = await _unitOfWork.EmployeeRepository.GetByEmployeeId(employeeId);

            if (currentEmployee == null)
            {
                return NotFound(new ResponseResult(404, "This employee is not existed"));
            }
            currentEmployee = _employeeMapper.MapEmployeeUpdateModelToEmployee(employeeUpdateModel, currentEmployee);

            await _unitOfWork.EmployeeRepository.UpdateAsync(currentEmployee);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete]
        [Route("id/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            var currentEmployee = await _unitOfWork.EmployeeRepository.GetByEmployeeId(employeeId);

            if (currentEmployee == null)
            {
                return NotFound(new ResponseResult(404, "This employee is not existed"));
            }
            try
            {
                await _unitOfWork.EmployeeRepository.SoftDelete(currentEmployee);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }



            return NoContent();
        }
    }
}
