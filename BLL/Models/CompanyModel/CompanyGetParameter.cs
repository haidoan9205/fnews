using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.CompanyModel
{
    public class CompanyGetParameter
    {
        public Guid CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Avatar { get; set; }
    }
}
