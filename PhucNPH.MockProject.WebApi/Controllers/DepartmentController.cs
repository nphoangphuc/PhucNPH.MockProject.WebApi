using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhucNPH.MockProject.Domain.Entities;
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
    [Route("departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentMapper _departmentMapper;
        private readonly IConfiguration _configuration;

        public DepartmentController(IUnitOfWork unitOfWork,
			IDepartmentMapper departmentMapper,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
			_departmentMapper = departmentMapper;
            _configuration = configuration;
        }

        [HttpPost]
		public async Task<IActionResult> CreateDepartment(DepartmentCreateModel departmentCreateModel)
        {
            var department = _departmentMapper.MapDepartmentCreateModelToDepartment(departmentCreateModel);
			department = await _unitOfWork.DepartmentRepository.CreateAsync(department);
            await _unitOfWork.SaveChangesAsync();

            return
                CreatedAtAction(nameof(GetDepartment),
                new { departmentId = department.Id },
                _departmentMapper.MapDepartmentToDepartmentModel(department));
        }

		[HttpGet]
		[Route("id/{departmentId}")]
		public async Task<ActionResult<DepartmentModel>> GetDepartment(Guid departmentId)
		{
			var department = await _unitOfWork.DepartmentRepository.GetByDepartmentId(departmentId);

			var departmentModel = _departmentMapper.MapDepartmentToDepartmentModel(department);
			if (departmentModel == null)
			{
				return NotFound(new ResponseResult(404, "This department is not existed"));
			}

			return departmentModel;
		}

		[HttpGet]
		public async Task<ActionResult<List<DepartmentModel>>> GetEmployeesInDepartments()
		{
			var departments = await _unitOfWork.DepartmentRepository.GetMultipleDepartmentEmployees();

			var departmentModels = departments.Select(department => _departmentMapper.MapDepartmentToDepartmentModel(department)).ToList();

			return departmentModels;
		}
	}
}
