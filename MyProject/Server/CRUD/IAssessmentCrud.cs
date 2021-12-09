using MyProject.Shared;

namespace MyProject.Server.CRUD
{
    public interface IAssessmentCrud
    {
        public Task<Assessment> CreateAssessment(Assessment Assessment);
        public Task<Assessment> GetAssessmentById(int Id);
        public Task<IEnumerable<Assessment>> GetAllAssessments();
        public Task<bool> UpdateAssessment(int Id);
        public Task<int> DeleteAssessment(int Id);
    }
}
