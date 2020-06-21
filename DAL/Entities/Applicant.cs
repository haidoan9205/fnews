using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Applicant
    {
        [Key]
        [Required]
        public Guid ApplicantId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public bool Gender { get; set; }

        public string Avatar { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string IdentifyCardNumer { get; set; }

        public string SeflDescribe { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool Status { get; set; }

        public string FcmKey { get; set; }
        public List<ApplicantSkill> ApplicantSkills { get; set; }
        public List<JobRequest> JobRequests { get; set; }
    }
}