using MyProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Server.CRUD
{
    public interface IAssessmentInfoCrud
    {
        public Task<AssessmentInfo> CreateAssessmentInfo(AssessmentInfo assessmentInfo);
        public Task<AssessmentInfo> GetAssessmentInfoById(int asmId);
        public Task<IEnumerable<AssessmentInfo>> GetAllAssessmentInfos();
        public Task<bool> UpdateAssessmentInfo(int asmId, AssessmentInfo assessmentInfo);
        public Task<int> DeleteAssessmentInfo(int asmId);
        
    }
}
