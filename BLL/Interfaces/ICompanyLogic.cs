using BLL.Models.CompanyModel;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Interfaces
{
    public interface ICompanyLogic
    {
        public bool Login(string email, string password);

        public IQueryable<Company> GetAllCompanies();

        public IQueryable<Company> GetNumberOfCompanies(int take);

        public Company GetCompanyById(Guid id);

        public List<CompanyViewModel> SearchCompanyByName(string? name, int page, int pageItem);

        public bool CreateNewCompany(CompanyCreateModel companyCreateModel);

        public bool UpdateCompany(CompanyUpdateModel companyUpdateModel);

        public bool DeleteCompany(Guid id);

        public int CountCompany();

        public IQueryable<JobRequest> GetJobRequests(Guid id);
    }
}