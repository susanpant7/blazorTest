using MyProject.Shared;
using System.Net.Http.Json;

namespace MyProject.Client.services
{
    public class PatientService : IPatientService
    {
        private readonly HttpClient httpClient;

        public PatientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            var response = await httpClient.PostAsJsonAsync<Patient>("/api/patients", patient);
            return await response.Content.ReadFromJsonAsync<Patient>();
        }

        public async Task DeletePatient(int Id)
        {
            await httpClient.DeleteAsync($"/api/patients/{Id}");
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Patient>>("/api/patients");
        }

        public async Task<Patient> GetPatientById(int Id)
        {
            var response = await httpClient.GetFromJsonAsync<Patient>($"/api/patients/{Id}");
            return response;
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            var response = await httpClient.
                PutAsJsonAsync<Patient>($"/api/patients/{patient.PatientId}", patient);
            return await response.Content.ReadFromJsonAsync<Patient>();
        }
    }
}
