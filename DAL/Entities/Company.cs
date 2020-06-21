using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Company
    {
        [Key]
        [Required]
        public Guid CompanyId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Avatar { get; set; }

        [Required]
        public string TaxIdentificationNumber { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool Status { get; set; }

        public string FcmKey { get; set; }
    }
}