using BLL.Helpers;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstanceJobPortal.Controllers
{   
    [Route("api/applicants")]
    public class ApplicantController : BaseController
    {
        private const string token = "e3g9BbU98jA:APA91bFjtVbFO8ZCgCg_VBzRVgavPM5qJ0AoFRJXE0R8pMs4R8HzSsONJgwS6mzAOwOJYamMBHBlO9X6gXXD5K2okMS5B2vdFkzPP7RIgR_wDFFnZsjvtHM3wE4_wovEEjWTrp3JsIuJ";
        private readonly IApplicantLogic _applicantLogic;
        private readonly INotification _notification;

        public ApplicantController(IApplicantLogic applicantLogic, INotification notification)
        {
            _applicantLogic = applicantLogic;
            _notification = notification;
        }

        [HttpGet]
        public async Task<IActionResult> ApplicantAsync()
        {
            List<Applicant> applicants = _applicantLogic.GetAllApplicants().ToList();
            if (applicants == null)
            {
                return BadRequest("Error");
            }  
            if (applicants.Count == 0)
            {
                return NotFound();
            }
            await _notification.SendNotification(token, "Fcm Message from admin", "this device had been hacked");

            return Ok(applicants);
        }

        [HttpGet("{id}")]
        public IActionResult Applicant(string id)
        {
            if (!Guid.TryParse(id, out Guid guid))
            {
                return BadRequest("Id wrong format");
            }
            Applicant applicant = _applicantLogic.GetApplicantById(guid);
            if (applicant == null)
            {
                return NotFound("This user not exist");
            }
            return Ok(applicant);
        }

        [HttpGet("search")]
        public IActionResult SearchApplicant(string name, [FromQuery]PagingModel pagingModel)
        {
            List<ApplicantViewModel> applicantViewModels = _applicantLogic.SearchApplicantByName(name, pagingModel);
            if (applicantViewModels == null)
            {
                return BadRequest("Error");
            }
            if (applicantViewModels.Count == 0)
            {
                return NotFound("There no applicant march this name");
            }
            return Ok(applicantViewModels);
        }

        [HttpPost]
        public IActionResult CreateApplicant(ApplicantCreateModel applicantCreateModel)
        {
            if (applicantCreateModel == null)
            {
                return BadRequest("Error");
            }
            bool check = _applicantLogic.CreateNewApplicant(applicantCreateModel);
            if (!check)
            {
                return BadRequest("Can not create new applicant");
            }
            return Ok("Success");
        }

        [HttpPut]
        public IActionResult UpdateApplicant([FromBody] ApplicantUpdateModel applicantUpdateModel)
        {
            Applicant applicant = _applicantLogic.GetApplicantById(applicantUpdateModel.ApplicantId);
            if (applicant == null)
            {
                return NoContent();
            }
            applicant.Address = applicantUpdateModel.Address;
            applicant.Avatar = applicantUpdateModel.Avatar;
            applicant.Birthdate = applicantUpdateModel.Birthdate;
            applicant.Email = applicantUpdateModel.Email;
            applicant.FullName = applicantUpdateModel.FullName;
            applicant.Gender = applicantUpdateModel.Gender;
            applicant.IdentifyCardNumer = applicantUpdateModel.IdentifyCardNumer;
            applicant.Phone = applicantUpdateModel.Phone;
            applicant.SeflDescribe = applicantUpdateModel.SeflDescribe;
            _applicantLogic.UpdateApplicant(applicant);
            return Ok("Applicant Info Updated");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateApplicant(string id, [FromBody] List<Guid> skillIds)
        {
            if (!Guid.TryParse(id, out Guid guid))
            {
                return BadRequest("Id wrong format");
            }
            if (id == null)
            {
                return BadRequest("Error");
            }
            _applicantLogic.UpdateApplicantSkill(guid, skillIds);
            return Ok("Skill updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteApplicant(Guid id)
        {
            var check = _applicantLogic.DeleteApplicant(id);
            if (!check)
            {
                return BadRequest("Error: Remove failed");
            }
            return Ok("Applicant Removed");
        }

        [HttpGet("count")]
        public IActionResult CountApplicant()
        {
            var count = _applicantLogic.CountApplicants();
            if (count < 0)
            {
                return BadRequest();
            }
            return Ok(count);
        }

        
    }
}