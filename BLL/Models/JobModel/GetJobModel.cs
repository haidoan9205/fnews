using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.JobModel
{
    public class GetJobModel
    {
        public Guid JobId { get; set; }

        public JobFilterModel JobFilterModel { get; set; }

        public PagingModel PagingModel { get; set; }
    }
}
