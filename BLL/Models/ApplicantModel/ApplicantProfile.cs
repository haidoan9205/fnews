using System;

namespace BLL.Models
{
    public class ApplicantProfile
    {
        public Guid ApplicantId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Gender { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public string IdentifyCardNumer { get; set; }
        public string SeflDescribe { get; set; }
    }
}