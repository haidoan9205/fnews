using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Admin
    {
        [Key]
        [Required]
        public Guid AdminId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}