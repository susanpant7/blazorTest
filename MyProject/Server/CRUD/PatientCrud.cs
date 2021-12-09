using Microsoft.EntityFrameworkCore;
using MyProject.Shared;

namespace MyProject.Server.CRUD
{
    public class PatientCrud : IPatientCrud
    {
        private readonly AppDbContext _db;
        public PatientCrud(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Patient> CreatePatient(Patient patient)
        {
            var result = await _db.Patients.AddAsync(patient);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeletePatient(int Id)
        {
            var patient = await _db.Patients.FindAsync(Id);
            if (patient != null)
            {
                _db.Patients.Remove(patient);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await _db.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientById(int Id)
        {
            return await _db.Patients.
                FirstOrDefaultAsync(p => p.PatientId.Equals(Id));
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            Patient currentPatientData = await _db.Patients
                .FirstOrDefaultAsync(p => p.PatientId == patient.PatientId);
            if (currentPatientData != null)
            {
                currentPatientData.FirstName = patient.FirstName;
                currentPatientData.LastName = patient.LastName;
                var updatedPatientData = _db.Patients.Update(currentPatientData);
                await _db.SaveChangesAsync();
                return currentPatientData;
            }
            return null;
        }
    }
}
