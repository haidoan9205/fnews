using BLL.Models.JobTypeModel;
using DAL.Entities;
using System;
using System.Linq;

namespace BLL.Interfaces
{
    public interface IJobTypeLogic
    {
        public IQueryable<JobType> GetAllJobTypes();

        public JobType GetJobTypeById(Guid id);

        public IQueryable<JobType> GetJobType(GetJobTypeModel getJobTypeModel);

        public bool UpdateJobType(JobTypeUpdateModel jobTypeUpdateModel);

        public bool CreateNewJobType(JobTypeCreateModel jobTypeCreateModel);

        public bool DeleteJobType(Guid id);
    }
}
