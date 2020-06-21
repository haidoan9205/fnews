using BLL.Helpers;
using BLL.Interfaces;
using BLL.Models.JobTypeModel;
using DAL.Entities;
using DAL.UnitOfWorks;
using System;
using System.Linq;

namespace BLL.BussinessLogics
{
    public class JobTypeLogic : IJobTypeLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobTypeLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool CreateNewJobType(JobTypeCreateModel jobTypeCreateModel)
        {
            bool check = false;
            if(jobTypeCreateModel != null)
            {
                JobType jobType = new JobType
                {
                    JobTypeId = Guid.NewGuid(),
                    JobTypeName = jobTypeCreateModel.JobTypeName,
                    CreatedDate = DateTime.Now,
                    Status = true
                };
                _unitOfWork.GetRepository<JobType>().Insert(jobType);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public bool DeleteJobType(Guid id)
        {
            bool check = false;
            JobType jobType = _unitOfWork.GetRepository<JobType>().FindById(id);
            if(jobType != null)
            {
                jobType.Status = false;
                _unitOfWork.GetRepository<JobType>().Update(jobType);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public IQueryable<JobType> GetAllJobTypes()
        {
            return _unitOfWork.GetRepository<JobType>().GetAll();
        }

        public IQueryable<JobType> GetJobType(GetJobTypeModel getJobTypeModel)
        {
            Paging paging = new Paging();
            IQueryable<JobType> jobTypes = _unitOfWork.GetRepository<JobType>().GetAll();
            if(!string.IsNullOrWhiteSpace(getJobTypeModel.JobTypeName))
            {
                jobTypes = jobTypes.Where(j => j.JobTypeName.ToLower().Contains(getJobTypeModel.JobTypeName.ToLower()));
            }

            if(!string.IsNullOrWhiteSpace(getJobTypeModel.SortOrder) && getJobTypeModel.SortOrder.Equals("desc"))
            {
                jobTypes.OrderByDescending(j => j.JobTypeName);
            }

            string[] filter = null;
            if(!string.IsNullOrWhiteSpace(getJobTypeModel.Filter))
            {
                filter = getJobTypeModel.Filter.Split(",");
            }

            jobTypes = jobTypes.Skip(paging.SkipItem(getJobTypeModel.page, getJobTypeModel.Limit));

            return jobTypes;
        }

        public JobType GetJobTypeById(Guid id)
        {
            JobType jobType = _unitOfWork.GetRepository<JobType>().FindById(id);
            return jobType;
        }

        public bool UpdateJobType(JobTypeUpdateModel jobTypeUpdateModel)
        {
            bool check = false;
            JobType jobType = _unitOfWork.GetRepository<JobType>().FindById(jobTypeUpdateModel.id);
            if(jobType != null)
            {
                jobType.JobTypeName = jobTypeUpdateModel.JobTypeName;
                _unitOfWork.GetRepository<JobType>().Update(jobType);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }
    }
}
