using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Shared
{
    public class AssessmentInfo
    {
        public int AssessmentInfoId { get; set; }

        [Required(ErrorMessage = "Please enter assessment name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter code")]
        public string? Code { get; set; }

        public string? Type { get; set; }

        [Required(ErrorMessage = "Please enter Json")]
        public string? AssessmentJson { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
