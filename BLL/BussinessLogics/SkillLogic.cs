using BLL.Interfaces;
using BLL.Models.SkillModel;
using DAL.Entities;
using DAL.UnitOfWorks;
using System;
using System.Linq;

namespace BLL.BussinessLogics
{
    public class SkillLogic : ISkillLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public SkillLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool CreateNewSkill(SkillCreateModel skillCreateModel)
        {
            bool check = false;
            if(skillCreateModel != null)
            {
                Skill skill = new Skill
                {
                    SkillId = Guid.NewGuid(),
                    SkillName = skillCreateModel.SkillName,
                    CreatedDate = DateTime.Now,
                    Status = true
                };
                _unitOfWork.GetRepository<Skill>().Insert(skill);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public bool DeleteSkill(Guid id)
        {
            bool check = false;
            Skill skill = _unitOfWork.GetRepository<Skill>().FindById(id);
            if(skill != null)
            {
                skill.Status = false;
                _unitOfWork.GetRepository<Skill>().Update(skill);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }

        public IQueryable<Skill> GetAllSkills()
        {
            return _unitOfWork.GetRepository<Skill>().GetAll();
        }

        public Skill GetSkillById(Guid id)
        {
            Skill skill = _unitOfWork.GetRepository<Skill>().FindById(id);
            return skill;
        }

        public bool UpdateSkill(SkillUpdateModel skillUpdateModel)
        {
            bool check = false;
            Skill skill = _unitOfWork.GetRepository<Skill>().FindById(skillUpdateModel.id);
            if(skill != null)
            {
                skill.SkillName = skillUpdateModel.Name;
                _unitOfWork.GetRepository<Skill>().Update(skill);
                _unitOfWork.Commit();
                check = true;
            }
            return check;
        }
    }
}
