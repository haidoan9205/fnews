using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.JobTypeModel
{
    public class JobTypeUpdateModel
    {
        public Guid id { get; set; }

        public string JobTypeName { get; set; }
    }
}
