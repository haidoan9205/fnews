using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Skill
    {
        [Key]
        [Required]
        public Guid SkillId { get; set; }

        [Required]
        public string SkillName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool Status { get; set; }

        public List<ApplicantSkill> ApplicantSkills { get; set; }
    }
}