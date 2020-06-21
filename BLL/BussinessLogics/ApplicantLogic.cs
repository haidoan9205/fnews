using BLL.Helpers;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.BussinessLogics
{
    public class ApplicantLogic : IApplicantLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicantLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }   

        public int CountApplicants()
        {

            int count = _unitOfWork.GetRepository<Applicant>().GetAll().Count();
            return count;
        }

        public bool CreateNewApplicant(ApplicantCreateModel applicantCreateModel)
        {
            bool check = false;
            if (applicantCreateModel != null)
            {
                Applicant applicant = new Applicant
                {
                    ApplicantId = Guid.NewGuid(),
                    Address = applicantCreateModel.Address,
                    Avatar = applicantCreateModel.Avatar,
                    Birthdate = applicantCreateModel.Birthdate,
                    Email = applicantCreateModel.Email,
                    FullName = applicantCreateModel.FullName,
                    Gender = applicantCreateModel.Gender,
                    IdentifyCardNumer = applicantCreateModel.IdentifyCardNumer,
                    Password = applicantCreateModel.Password,
                    Phone = applicantCreateModel.Phone,
                    SeflDescribe = applicantCreateModel.SeflDescribe,
                    CreatedDate = DateTime.UtcNow,
                    Status = true,
                    ApplicantSkills = null
                };
                _unitOfWork.GetRepository<Applicant>().Insert(applicant);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public bool DeleteApplicant(Guid id)
        {
            bool check = false;
            Applicant applicant = _unitOfWork.GetRepository<Applicant>().FindById(id);
            if (applicant != null)
            {
                applicant.Status = false;
                _unitOfWork.GetRepository<Applicant>().Update(applicant);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public IQueryable<Applicant> GetAllApplicants()
        {
            IQueryable<Applicant> applicants = _unitOfWork.GetRepository<Applicant>().GetAll();
            return applicants;
        }

        public Applicant GetApplicantById(Guid id)
        {
            Applicant applicant = _unitOfWork.GetRepository<Applicant>().FindById(id);
            return applicant;
        }

        public IQueryable<ApplicantSkill> GetApplicantSkills(Guid id)
        {
            IQueryable<ApplicantSkill> SkillList = _unitOfWork.GetRepository<ApplicantSkill>().GetAll().Where(s => s.ApplcantId == id);
            return SkillList;
        }

        public IQueryable<JobRequest> GetJobRequests(Guid id)
        {
            IQueryable<JobRequest> jobRequests = _unitOfWork.GetRepository<JobRequest>().GetAll().Where(j => j.ApplicantId == id);
            return jobRequests;
        }

        public List<ApplicantViewModel> SearchApplicantByName(string name, PagingModel pagingModel)
        {
            IEnumerable<ApplicantViewModel> applicantViewModels = _unitOfWork
                .GetRepository<Applicant>()
                .GetAll()
                .Where(a => a.FullName.Contains(name))
                .Select(a => new ApplicantViewModel
                {
                    ApplicantId = a.ApplicantId,
                    Email = a.Email,
                    FullName = a.FullName,
                    Gender = a.Gender,
                    Phone = a.Phone
                });
            if (applicantViewModels != null)
            {
                var paging = new Paging();
                if (name == null)
                {
                    name = "";
                }
                var searchName = name.ToLower();
                var result = new List<ApplicantViewModel>();
                result = applicantViewModels
                    .Where(a => a.FullName.ToLower().Contains(name))
                    .OrderBy(a => a.FullName)
                    .Skip(paging.SkipItem(pagingModel.PageNumber, pagingModel.PageSize))
                    .Take(pagingModel.PageSize)
                    .ToList();
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        public bool UpdateApplicant(Applicant applicant)
        {
            bool check = false;
            if (applicant != null)
            {
                _unitOfWork.GetRepository<Applicant>().Update(applicant);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public void UpdateApplicantSkill(Guid applicantId, List<Guid> skillGuids)
        {
            List<ApplicantSkill> thisApplicantSkills = _unitOfWork.GetRepository<ApplicantSkill>()
                .GetAll()
                .Include(a => a.Skill)
                .Where(a => a.ApplcantId.Equals(applicantId))
                .ToList();
            foreach (var skill in thisApplicantSkills)
            {
                if (skillGuids.Contains(skill.SkillId))
                {
                    _unitOfWork.GetRepository<ApplicantSkill>().Update(new ApplicantSkill
                    {
                        ApplcantId = applicantId,
                        SkillId = skill.SkillId,
                        Status = true
                    });
                }
                else
                {
                    if (skill.Status)
                    {
                        _unitOfWork.GetRepository<ApplicantSkill>().Update(new ApplicantSkill
                        {
                            ApplcantId = applicantId,
                            SkillId = skill.SkillId,
                            Status = false
                        });
                    }
                    var check = _unitOfWork.GetRepository<ApplicantSkill>().GetAll()
                        .Where(a => a.ApplcantId == applicantId)
                        .Any(a => a.SkillId == skill.SkillId);
                    if (!check)
                    {
                        _unitOfWork.GetRepository<ApplicantSkill>().Insert(new ApplicantSkill
                        {
                            ApplcantId = applicantId,
                            SkillId = skill.SkillId,
                            Status = true
                        });
                    }
                }
            }
            _unitOfWork.Commit();
        }
    }
}