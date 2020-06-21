﻿using System;

namespace BLL.Models.CompanyModel
{
    public class CompanyCreateModel
    {
        public string Password { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Avatar { get; set; }

        public string TaxIdentificationNumber { get; set; }
    }
}