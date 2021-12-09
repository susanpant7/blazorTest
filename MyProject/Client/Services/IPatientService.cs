using MyProject.Shared;

namespace MyProject.Client.services
{
    public interface IPatientService
    {
        public Task<Patient> CreatePatient(Patient Patient);
        public Task<Patient> GetPatientById(int Id);
        public Task<IEnumerable<Patient>> GetAllPatients();
        public Task<Patient> UpdatePatient(Patient patient);
        public Task DeletePatient(int Id);
    }
}
