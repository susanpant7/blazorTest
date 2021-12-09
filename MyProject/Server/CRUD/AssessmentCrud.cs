using Microsoft.EntityFrameworkCore;
using MyProject.Shared;

namespace MyProject.Server.CRUD
{
    public class AssessmentCrud : IAssessmentCrud
    {
        private readonly AppDbContext _db;
        public AssessmentCrud(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Assessment> CreateAssessment(Assessment assessment)
        {
            if (assessment.AssessmentInfo != null)
            {
                _db.Entry(assessment.AssessmentInfo);
            }
            var result = await _db.Assessments.AddAsync(assessment);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public Task<int> DeleteAssessment(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Assessment>> GetAllAssessments()
        {
            throw new NotImplementedException();
        }

        public async Task<Assessment> GetAssessmentById(int Id)
        {
            return await _db.Assessments
                .Include(a => a.Patient)
                .Include(a => a.AssessmentInfo)
                .FirstOrDefaultAsync(a => a.AssessmentId == Id);
        }

        public Task<bool> UpdateAssessment(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
