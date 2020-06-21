using BLL.Models.SkillModel;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Interfaces
{
    public interface ISkillLogic
    {
        public IQueryable<Skill> GetAllSkills();

        public Skill GetSkillById(Guid id);

        public bool CreateNewSkill(SkillCreateModel skillCreateModel);

        public bool UpdateSkill(SkillUpdateModel skillUpdateModel);

        public bool DeleteSkill(Guid id);


    }
}
