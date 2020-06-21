using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class ApplicantSkill
    {
        [Required]
        public Guid ApplcantId { get; set; }

        public Applicant Applicant { get; set; }

        [Required]
        public Guid SkillId { get; set; }

        public Skill Skill { get; set; }

        public bool Status { get; set; }
    }
}