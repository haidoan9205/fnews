using System;

namespace BLL.Models
{
    public class ApplicantSkillModel
    {
        public Guid ApplcantId { get; set; }

        public Guid SkillId { get; set; }

        public bool Status { get; set; }
    }
}