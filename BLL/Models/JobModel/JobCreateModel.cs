using System;

namespace BLL.Models.JobModel
{
    public class JobCreateModel
    {
        public string JobName { get; set; }
        public float Salary { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }
        public string JobDescription { get; set; }
        public DateTime CloseDate { get; set; }
        public bool Status { get; set; }
    }
}