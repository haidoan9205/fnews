using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ILoginLogic
    {
        public string LoginApplicant(string email, string password);
        public string LoginCompany(string email, string password);
    }
}
