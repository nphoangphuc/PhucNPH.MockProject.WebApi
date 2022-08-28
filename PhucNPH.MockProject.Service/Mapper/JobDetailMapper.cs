using Microsoft.AspNet.Identity;
using PhucNPH.MockProject.Domain.Entities;
using PhucNPH.MockProject.Domain.Models;

namespace PhucNPH.MockProject.Service.Mapper
{
    public interface IJobDetailMapper
    {
        JobDetail MapJobDetailCreateModelToJobDetail(JobDetailCreateModel jobDetailCreateModel);
        JobDetailModel MapJobDetailToJobDetailModel(JobDetail jobDetail);
    }

    public class JobDetailMapper : IJobDetailMapper
    {
        public JobDetail MapJobDetailCreateModelToJobDetail(JobDetailCreateModel jobDetailCreateModel)
        {
            if(jobDetailCreateModel == null)
            {
                return null;
            }

            return new JobDetail
            {
                JobDescription = jobDetailCreateModel.JobDescription,
                JobLevel = jobDetailCreateModel.JobLevel,
                JobTitle = Enum.Parse<JobTitle>(jobDetailCreateModel.JobTitle)
            };
        }

        public JobDetailModel MapJobDetailToJobDetailModel(JobDetail jobDetail)
        {
            if( jobDetail == null)
            {
                return null;
            }

            return new JobDetailModel
            {
                Id = jobDetail.Id,
                JobDescription = jobDetail.JobDescription,
                JobLevel = jobDetail.JobLevel,
                JobTitle = jobDetail.JobTitle.ToString()
            };
        }
    }
}
