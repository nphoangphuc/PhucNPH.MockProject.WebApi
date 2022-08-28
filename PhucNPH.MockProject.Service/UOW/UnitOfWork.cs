using PhucNPH.MockProject.Repository.Infrastructure;
using PhucNPH.MockProject.Repository.Infrastructure.Repository;

namespace PhucNPH.MockProject.Service.UOW
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IJobDetailRepository JobDetailRepository { get; }
        Task SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IEmployeeRepository _employeeRepository;
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_dbContext);
                }

                return _employeeRepository;
            }
        }

		private IDepartmentRepository _departmentRepository;
		public IDepartmentRepository DepartmentRepository
		{
			get
			{
				if (_departmentRepository == null)
				{
					_departmentRepository = new DepartmentRepository(_dbContext);
				}

				return _departmentRepository;
			}
		}

        private IJobDetailRepository _jobDetailRepository;
		public IJobDetailRepository JobDetailRepository
		{
			get
			{
				if (_jobDetailRepository == null)
				{
					_jobDetailRepository = new JobDetailRepository(_dbContext);
				}

				return _jobDetailRepository;
			}
		}

		public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
