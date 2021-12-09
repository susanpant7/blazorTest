using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Shared
{
    public class Assessment
    {
        public int AssessmentId { get; set; }
        public string Status { get; set; }
        public string AssessmentJson { get; set; }
        public int AssessmentInfoId { get; set; }
        public AssessmentInfo AssessmentInfo { get; set; }
        public int PatientId { get; set; }
        public Patient  Patient { get; set; }
    }
}
