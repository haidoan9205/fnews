using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class PayType
    {
        [Key]
        [Required]
        public Guid PayTypeId { get; set; }

        [Required]
        public string PayTypeName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}