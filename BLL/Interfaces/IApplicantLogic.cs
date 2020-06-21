using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Interfaces
{
    public interface IApplicantLogic
    {
        public IQueryable<Applicant> GetAllApplicants();

        public Applicant GetApplicantById(Guid id);

        public List<ApplicantViewModel> SearchApplicantByName(String name, PagingModel pagingModel);

        public bool CreateNewApplicant(ApplicantCreateModel applicantCreateModel);

        public void UpdateApplicantSkill(Guid applicantId, List<Guid> skillGuids);

        public bool UpdateApplicant(Applicant applicant);

        public bool DeleteApplicant(Guid id);

        public int CountApplicants();

        public IQueryable<JobRequest> GetJobRequests(Guid id);

        public IQueryable<ApplicantSkill> GetApplicantSkills(Guid id);
    }
}