using BLL.Helpers;
using BLL.Interfaces;
using BLL.Models.CompanyModel;
using DAL.Entities;
using DAL.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.BussinessLogics
{
    public class CompanyLogic : ICompanyLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int CountCompany()
        {
            int count = _unitOfWork.GetRepository<Company>().GetAll().Count();
            return count;
        }

        public bool CreateNewCompany(CompanyCreateModel companyCreateModel)
        {
            bool check = false;
            if (companyCreateModel != null)
            {
                Company company = new Company
                {
                    CompanyId = Guid.NewGuid(),
                    Password = companyCreateModel.Password,
                    CompanyName = companyCreateModel.CompanyName,
                    Address = companyCreateModel.Address,
                    Email = companyCreateModel.Email,
                    Phone = companyCreateModel.Phone,
                    Status = true,
                    Avatar = companyCreateModel.Avatar,
                    CreatedDate = DateTime.UtcNow,
                    TaxIdentificationNumber = companyCreateModel.TaxIdentificationNumber
                };

                _unitOfWork.GetRepository<Company>().Insert(company);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public bool DeleteCompany(Guid id)
        {
            bool check = false;
            Company company = _unitOfWork.GetRepository<Company>().FindById(id);
            if (company != null)
            {
                company.Status = false;
                _unitOfWork.GetRepository<Company>().Update(company);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public IQueryable<Company> GetAllCompanies()
        {
            IQueryable<Company> companies = _unitOfWork.GetRepository<Company>().GetAll();
            return companies;
        }

        public Company GetCompanyById(Guid id)
        {
            Company company = _unitOfWork.GetRepository<Company>().FindById(id);
            return company;
        }

        public IQueryable<Company> GetNumberOfCompanies(int take)
        {
            IQueryable<Company> companies = _unitOfWork.GetRepository<Company>().GetAll().Take(take);
            if(!companies.Any())
            {
                return null;
            }
            return companies;
        }

        public IQueryable<JobRequest> GetJobRequests(Guid id)
        {
            IQueryable<JobRequest> jobRequests = _unitOfWork.GetRepository<JobRequest>().GetAll().Where(job => job.JobId == id);
            return jobRequests;
        }

        public bool Login(string email, string password)
        {
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            IQueryable<Company> companies = _unitOfWork.GetRepository<Company>().GetAll().Where(c => c.Email == email && c.Password == password);
            if (companies != null)
            {
                return true;
            }
            return false;
        }

        public List<CompanyViewModel> SearchCompanyByName(string? name, int page, int pageItem)
        {
            IEnumerable<CompanyViewModel> companyList = _unitOfWork
                .GetRepository<Company>()
                .GetAll()
                .Where(company => company.CompanyName.ToLower().Contains(name.ToLower()))
                .Select(company => new CompanyViewModel
                {
                    CompanyId = company.CompanyId,
                    CompanyName = company.CompanyName,
                    Address = company.Address,
                    Email = company.Email,
                    Status = company.Status,
                    Phone = company.Phone,
                    Avatar = company.Avatar
                });

            if (companyList != null)
            {
                var paging = new Paging();
                var searchName = name.ToLower();
                var result = new List<CompanyViewModel>();
                result = companyList.Where(c => c.CompanyName.ToLower().Contains(name))
                                    .OrderBy(c => c.CompanyName)
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

        public bool UpdateCompany(CompanyUpdateModel companyUpdateModel)
        {
            bool check = false;
            Company company = _unitOfWork.GetRepository<Company>().FindById(companyUpdateModel.CompanyId);
            if (company != null)
            {
                company.CompanyId = companyUpdateModel.CompanyId;
                company.Password = companyUpdateModel.Password;
                company.CompanyName = companyUpdateModel.CompanyName;
                company.Address = companyUpdateModel.Address;
                company.Email = companyUpdateModel.Email;
                company.Status = companyUpdateModel.Status;
                company.Phone = companyUpdateModel.Phone;
                company.Avatar = companyUpdateModel.Avatar;
                _unitOfWork.GetRepository<Company>().Update(company);
                _unitOfWork.Commit();
                check = true;
            }

            return check;
        }
    }
}