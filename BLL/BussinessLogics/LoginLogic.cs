using BLL.Helpers;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.UnitOfWorks;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace BLL.BussinessLogics
{
    public class LoginLogic : ILoginLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IOptions<AppSetting> _options;
        public LoginLogic(IUnitOfWork unitOfWork, IOptions<AppSetting> options)
        {
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public string LoginApplicant(string email, string password)
        {
            TokenManager tokenManager = new TokenManager(_options);
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password))
            {
                return null;
            }
            Applicant applicant = _unitOfWork.GetRepository<Applicant>().GetAll().SingleOrDefault(a => a.Email.Equals(email) && a.Password.Equals(password));
            if(applicant == null || applicant.Status == false)
            {
                return null;
            }
            string tokenString =  tokenManager.CreateAccessToken(new UserProfile
            {
                Email = applicant.Email,
                Name = applicant.FullName,
                Role = "Applicant"
                
            });
            return tokenString;
        }

        public string LoginCompany(string email, string password)
        {
            TokenManager tokenManager = new TokenManager(_options);
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password))
            {
                return null;
            }
            Company company = _unitOfWork.GetRepository<Company>().GetAll().SingleOrDefault(a => a.Email.Equals(email) && a.Password.Equals(password));
            if(company == null || company.Status == false)
            {
                return null;
            }
            string tokenString = tokenManager.CreateAccessToken(new UserProfile
            {
                Email = company.Email,
                Name = company.CompanyName,
                Role = "Company"
            });
            return tokenString;
        }

        
    }
}