using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interfaces;
using BLL.Models.SkillModel;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstanceJobPortal.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        ISkillLogic _skillLogic;

        public SkillController(ISkillLogic skillLogic)
        {
            _skillLogic = skillLogic;
        }

        [HttpGet]
        public IActionResult GetAllSkills()
        {
            List<Skill> skills = _skillLogic.GetAllSkills().ToList();
            if(!skills.Any())
            {
                return NotFound();
            }

            return Ok(skills);
        }


        [HttpGet("{id}")]
        public IActionResult GetSkillById(Guid id)
        {
            if(string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest("Incorrect Parameter");
            }
            Skill skill = _skillLogic.GetSkillById(id);

            if(skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }

        [HttpPost]
        public IActionResult CreateNewSkill(SkillCreateModel skillCreateModel)
        {
            if(skillCreateModel == null)
            {
                return BadRequest("Incorrect Parameter");
            }
            bool check = _skillLogic.CreateNewSkill(skillCreateModel);

            if(!check)
            {
                return BadRequest("Create Error");
            }

            return Ok("Create Skill Success");
        }

        [HttpPut]
        public IActionResult UpdateSkill(SkillUpdateModel skillUpdateModel)
        {
            if(skillUpdateModel == null)
            {
                return BadRequest("Incorrect Parameter");
            }

            bool check = _skillLogic.UpdateSkill(skillUpdateModel);

            if(!check)
            {
                return BadRequest("Update Error");
            }

            return Ok("Update Skill Success");
        }

        [HttpDelete]
        public IActionResult DeleteSkill(Guid id)
        {
            if(string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest("Incorrect Parameter");
            }

            bool check = _skillLogic.DeleteSkill(id);
            if(!check)
            {
                return BadRequest("Delete Error");
            }

            return Ok("Delete Skill Success");
        }
    
    }
}