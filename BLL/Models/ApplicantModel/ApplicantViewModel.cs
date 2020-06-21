using System;

namespace BLL.Models
{
    public class ApplicantViewModel
    {
        public Guid ApplicantId { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string FullName { get; set; }

        public bool Gender { get; set; }
    }
}