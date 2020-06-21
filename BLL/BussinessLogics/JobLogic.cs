using BLL.Helpers;
using BLL.Interfaces;
using BLL.Models.JobModel;
using DAL.Entities;
using DAL.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.BussinessLogics
{
    public class JobLogic : IJobLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int CountJobs()
        {
            int count = _unitOfWork.GetRepository<Applicant>().GetAll().Count();
            return count;
        }

        public bool CreateNewJob(JobCreateModel jobCreateModel)
        {
            bool check = false;
            if (jobCreateModel != null)
            {
                Job job = new Job
                {
                    JobId = Guid.NewGuid(),
                    JobName = jobCreateModel.JobName,
                    Salary = jobCreateModel.Salary,
                    BeginDate = jobCreateModel.BeginDate,
                    EndDate = jobCreateModel.EndDate,
                    JobDescription = jobCreateModel.JobDescription,
                    CloseDate = jobCreateModel.CloseDate,
                    CreatedDate = DateTime.UtcNow,
                    Status = jobCreateModel.Status
                };
                _unitOfWork.GetRepository<Job>().Insert(job);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public bool DeleteJob(Guid id)
        {
            bool check = false;
            Job job = _unitOfWork.GetRepository<Job>().FindById(id);
            if (job != null)
            {
                job.Status = false;
                _unitOfWork.GetRepository<Job>().Update(job);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public Job GetJobById(Guid id)
        {
            Job job = _unitOfWork.GetRepository<Job>().FindById(id);
            return job;
        }

        public IQueryable<Job> GetJobs()
        {
            IQueryable<Job> jobs = _unitOfWork.GetRepository<Job>().GetAll();
            return jobs;
        }

        public List<JobViewModel> SearchJobByName(string name, int page, int pageItem)
        {
            IEnumerable<JobViewModel> jobViewModels = _unitOfWork
                .GetRepository<Job>()
                .GetAll()
                .Where(a => a.JobName.Contains(name))
                .Select(a => new JobViewModel
                {
                    JobId = a.JobId,
                    JobName = a.JobName,
                    Salary = a.Salary,
                    Status = a.Status,
                    BeginDate = a.BeginDate,
                    EndDate = a.EndDate
                });
            if (jobViewModels != null)
            {
                var paging = new Paging();
                if (name == null)
                {
                    name = "";
                }
                var searchName = name.ToLower();
                var result = new List<JobViewModel>();
                result = jobViewModels
                    .Where(a => a.JobName.ToLower().Contains(name))
                    .OrderBy(a => a.JobName)
                    .Skip(paging.SkipItem(page, pageItem))
                    .Take(pageItem)
                    .ToList();
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public bool UpdateJob(Job job)
        {
            bool check = false;
            if (job != null)
            {
                _unitOfWork.GetRepository<Job>().Update(job);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }


    }
}