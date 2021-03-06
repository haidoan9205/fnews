﻿using System;

namespace BLL.Models.CompanyModel
{
    public class CompanyViewModel
    {
        public Guid CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public bool Status { get; set; }

        public string Phone { get; set; }

        public string Avatar { get; set; }
    }
}