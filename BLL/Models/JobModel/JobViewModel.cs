using System;

namespace BLL.Models.JobModel
{
    public class JobViewModel
    {
        public Guid JobId { get; set; }
        public string JobName { get; set; }
        public float Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
    }
}