using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class JobType
    {
        [Key]
        [Required]
        public Guid JobTypeId { get; set; }

        [Required]
        public string JobTypeName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}