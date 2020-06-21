using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class JobRequest
    {
        [Required]
        public Guid JobId { get; set; }

        public Job Job { get; set; }

        [Required]
        public Guid ApplicantId { get; set; }

        public Applicant Applicant { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public bool IsAccept { get; set; }
    }
}