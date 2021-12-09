using MyProject.Shared;

namespace MyProject.Server.CRUD
{
    public interface IPatientCrud
    {
        public Task<Patient> CreatePatient(Patient Patient);
        public Task<Patient> GetPatientById(int Id);
        public Task<IEnumerable<Patient>> GetAllPatients();
        public Task<Patient> UpdatePatient(Patient patient);
        public Task<int> DeletePatient(int Id);
    }
}
