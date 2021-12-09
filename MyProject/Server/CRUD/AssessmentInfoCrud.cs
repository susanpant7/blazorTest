using Microsoft.EntityFrameworkCore;
using MyProject.Server.CRUD;
using MyProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Server.CRUD
{
    public class AssessmentInfoCrud : IAssessmentInfoCrud
    {
        private readonly AppDbContext _db;
        public AssessmentInfoCrud(AppDbContext db)
        {
            _db = db;
        }

        public async Task<AssessmentInfo> CreateAssessmentInfo(AssessmentInfo assessmentInfo)
        {
            assessmentInfo.CreatedDate = DateTime.Now;
            assessmentInfo.CreatedBy = "";
            await _db.AssessmentInfos.AddAsync(assessmentInfo);
            await _db.SaveChangesAsync();
            return assessmentInfo;
        }

        public async Task<IEnumerable<AssessmentInfo>> GetAllAssessmentInfos()
        {
            return await _db.AssessmentInfos.ToListAsync();
        }

        public async Task<AssessmentInfo> GetAssessmentInfoById(int asmId)
        {
            return await _db.AssessmentInfos.
                FirstOrDefaultAsync(ai => ai.AssessmentInfoId.Equals(asmId));
        }

        public async Task<bool> UpdateAssessmentInfo(int asmId, AssessmentInfo assessmentInfo)
        {
            AssessmentInfo asm = await _db.AssessmentInfos.FindAsync(asmId);
            asm = assessmentInfo;
            asm.UpdatedBy = "";
            asm.UpdatedDate = DateTime.Now;
            var updatedAsm = _db.AssessmentInfos.Update(asm);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<int> DeleteAssessmentInfo(int asmId)
        {
            var asm = await _db.AssessmentInfos.FindAsync(asmId);
            if (asm != null)
            {
                _db.AssessmentInfos.Remove(asm);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
    }
}
