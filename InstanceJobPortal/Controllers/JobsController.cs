using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using BLL.Interfaces;
using BLL.Models.JobModel;

namespace InstanceJobPortal.Controllers
{
	[Route("api/jobs")]
	public class JobsController : BaseController
	{
		private readonly IJobLogic _jobLogic;
		public JobsController(IJobLogic jobLogic)
		{
			_jobLogic = jobLogic;
		}

		//[HttpGet]
		//public IActionResult GetJob([FromQuery] GetJobModel getJobModel)
		//{
		//	List<JobViewModel> jobViewModels = null;
		//	if(getJobModel == null)
		//	{   
		//		var jobs = _jobLogic.GetJobs();
		//		if(jobs.Count() > 0)
		//		{
		//			foreach(Job job in jobs)
		//			{
		//				JobViewModel model = new JobViewModel
		//				{
		//					BeginDate = job.BeginDate,
		//					EndDate = job.EndDate,
		//					JobId = job.JobId,
		//					JobName = job.JobName,
		//					Salary = job.Salary,
		//					Status = job.Status
		//				};
		//				jobViewModels.Add(model);
		//			}
		//		}
		//	}
				
		//}        

		[HttpGet]
		public IActionResult Get()
        {
			var jobs =_jobLogic.GetJobs();
			return Ok(jobs);
        }

		[HttpPost]
		public IActionResult Post(JobCreateModel jobCreateModel)
        {
			var check = _jobLogic.CreateNewJob(jobCreateModel);
			if(!check)
            {
				return BadRequest("Create failed");
            }
			return Ok("Created");
        }

		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
        {
			var job = _jobLogic.GetJobById(id);
			return Ok(job);
        }

        //[HttpGet("filter")]
        //public IActionResult Get([FromQuery]  )
        //{

        //}
    }
}
