using BLL.Models.JobModel;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Interfaces
{
    public interface IJobLogic
    {
        public IQueryable<Job> GetJobs();

        public Job GetJobById(Guid id);

        public List<JobViewModel> SearchJobByName(String name, int page, int pageItem);

        public bool CreateNewJob(JobCreateModel jobCreateModel);

        public bool UpdateJob(Job job);

        public bool DeleteJob(Guid id);

        public int CountJobs();
    }
}