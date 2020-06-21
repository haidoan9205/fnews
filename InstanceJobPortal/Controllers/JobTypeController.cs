using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using BLL.Models.JobTypeModel;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstanceJobPortal.Controllers
{
    [Route("api/job-types")]
    [ApiController]
    public class JobTypeController : ControllerBase
    {
        private readonly IJobTypeLogic _jobTypeLogic;

        public JobTypeController(IJobTypeLogic jobTypeLogic)
        {
            _jobTypeLogic = jobTypeLogic;
        }

        [HttpGet]
        public IActionResult GetAllJobTypes()
        {
            List<JobType> jobTypes = _jobTypeLogic.GetAllJobTypes().ToList();
            if(!jobTypes.Any())
            {
                return NotFound();
            }

            return Ok(jobTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetJobType(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || Guid.TryParse(id, out Guid guid))
            {
                return BadRequest("Incorrect Parameter");
            }

            JobType jobType = _jobTypeLogic.GetJobTypeById(guid);
            if(jobType == null)
            {
                return NotFound();
            }

            return Ok(jobType);
        }


        [HttpPost]
        public IActionResult CreateNewJobType(JobTypeCreateModel jobTypeCreateModel)
        {
            if(jobTypeCreateModel == null)
            {
                return BadRequest("Incorrect Parameter");
            }

            bool check = _jobTypeLogic.CreateNewJobType(jobTypeCreateModel);
            if(!check)
            {
                return BadRequest("Create Error");
            }
            return Ok("Create JobType Success");
        }

        [HttpPut]
        public IActionResult UpdateJobType(JobTypeUpdateModel jobTypeUpdateModel)
        {
            if(jobTypeUpdateModel == null)
            {
                return BadRequest("Incorrect Parameter");
            }

            bool check = _jobTypeLogic.UpdateJobType(jobTypeUpdateModel);
            if(!check)
            {
                return BadRequest("Update Error");
            }

            return Ok("Update JobType Success");
        }

        [HttpDelete]
        public IActionResult DeleteJobType(Guid id)
        {
            if(string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest("Incorrect Parameter");
            }

            bool check = _jobTypeLogic.DeleteJobType(id);
            if(!check )
            {
                return BadRequest("Delete error");
            }
            return Ok("Delete JobType Success");
        }
    }
}