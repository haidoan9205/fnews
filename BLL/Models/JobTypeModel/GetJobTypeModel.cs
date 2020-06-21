using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.JobTypeModel
{
    public class GetJobTypeModel
    {
        public string? JobTypeName { get; set; }

        public int page { get; set; }

        public int Limit { get; set; }

        public string? SortOrder { get; set; }

        public string? Filter { get; set; }

    }
}
