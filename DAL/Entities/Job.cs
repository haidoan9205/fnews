using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Job
    {
        [Key]
        [Required]
        public Guid JobId { get; set; }

        [Required]
        public string JobName { get; set; }

        [Required]
        public float Salary { get; set; }

        [Required]
        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string JobDescription { get; set; }

        [Required]
        public DateTime CloseDate { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool Status { get; set; }

        public Company Company { get; set; }

        public JobType JobType { get; set; }

        public PayType PayType { get; set; }

        public List<JobRequest> JobRequests { get; set; }
    }
}