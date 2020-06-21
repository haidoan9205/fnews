using System;

namespace BLL.Models.JobModel
{
    public class JobFilterModel
    {

        public JobFilterModel()
        {
            Salary = 0;
            BeginDate = DateTime.MinValue;
            Status = true;
            CompanyName = null;
            JobType = null;
            PayType = null;
        }

        public JobFilterModel(float? salary, DateTime? beginDate, bool? statsus, string companyName, string jobType, string payType)
        {
            Salary = salary;
            BeginDate = beginDate;
            Status = statsus;
            CompanyName = companyName;
            JobType = jobType;
            PayType = payType;
        }
        public float? Salary { get; set; }
        public DateTime? BeginDate { get; set; }
        public bool? Status { get; set; }
        public string CompanyName { get; set; }
        public string JobType { get; set; }
        public string PayType { get; set; }

    }
}
