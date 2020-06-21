using BLL.Interfaces;
using BLL.Models.CompanyModel;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InstanceJobPortal.Controllers
{
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyLogic _companyLogic;

        public CompanyController(ICompanyLogic companyLogic)
        {
            _companyLogic = companyLogic;
        }

        [HttpGet]
        public IActionResult GetCompany()
        {
            List<Company> companies = _companyLogic.GetAllCompanies().ToList();
            if (companies == null)
            {
                return BadRequest("Error");
            }
            if (companies.Count == 0)
            {
                return NotFound();
            }

            return Ok(companies);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompany(Guid id)
        {
            Company company = _companyLogic.GetCompanyById(id);
            if (company == null)
            {
                return BadRequest("Error");
            }

            return Ok(company);
        }

        //[HttpGet("{take}")]
        //public IActionResult GetCompany(int take)
        //{
        //    List<Company> companies = _companyLogic.GetNumberOfCompanies(take).ToList();
        //    if(companies == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(companies);
        //}

        [HttpGet("{name}, {page}, {pageItem}")]
        public IActionResult GetCompany(string? name, int page, int pageItem)
        {
            List<CompanyViewModel> companyViewModels = _companyLogic.SearchCompanyByName(name, page, pageItem);

            if (companyViewModels == null)
            {
                return BadRequest("Error");
            }

            return Ok(companyViewModels);
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody]CompanyCreateModel companyCreateModel)
        {
            if (companyCreateModel == null)
            {
                return BadRequest("Error");
            }
            bool check = _companyLogic.CreateNewCompany(companyCreateModel);
            if (check)
            {
                return Ok("Create New Company Successful");
            }
            else
            {
                return BadRequest("Cannot Create New Company");
            }
        }

        [HttpPut]
        public IActionResult UpdateCompany([FromBody]CompanyUpdateModel companyUpdateModel)
        {
            if (companyUpdateModel == null)
            {
                return NoContent();
            }

            bool check = _companyLogic.UpdateCompany(companyUpdateModel);

            if (check)
            {
                return Ok("Update Company Successful");
            }
            else
            {
                return BadRequest("Cannot Update Company");
            }
        }

        [HttpDelete]
        public IActionResult DeleteCompany(Guid id) {
            bool check = _companyLogic.DeleteCompany(id);
            if(check) {
                return Ok("Delete Success");
            }
            return BadRequest("Delete Error");

        }
    }
}