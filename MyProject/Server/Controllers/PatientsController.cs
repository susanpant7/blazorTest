using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Server.CRUD;
using MyProject.Shared;

namespace MyProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {

        private readonly IPatientCrud patientCrud;

        public PatientsController(IPatientCrud patientCrud)
        {
            this.patientCrud = patientCrud;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAllPatients()
        {
            try
            {
                return Ok(await patientCrud.GetAllPatients());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Patient>> GetPatientById(int id)
        {
            try
            {
                var patient = await patientCrud.GetPatientById(id);
                if (patient == null)
                {
                    return NotFound();
                } else
                {
                    return patient;
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<ActionResult> CreatePatient(Patient patient)
        {
            try
            {
                if(patient == null)
                {
                    return BadRequest();
                }
                var newPatient = await patientCrud.CreatePatient(patient);
                return CreatedAtAction(nameof(GetPatientById),
                    new { id=newPatient.PatientId}, newPatient);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("id:int")]
        public async Task<ActionResult<Patient>> UpdatePatient(int id, Patient patient)
        {
            try
            {
                if (id != patient.PatientId)
                {
                    return BadRequest();
                }
                var patientToUpdate = await patientCrud.GetPatientById(id);
                if (patientToUpdate == null)
                {
                    return NotFound($"Patient with id {id} not found");
                }
                return await patientCrud.UpdatePatient(patientToUpdate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating patient");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            try
            {
                var patientToDelete = await patientCrud.GetPatientById(id);
                if (patientToDelete == null)
                {
                    return NotFound($"Patient with id {id} not found");
                }
                await patientCrud.DeletePatient(id);
                return Ok($"Patient with id {id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting patient");
            }
        }

        //[HttpGet("{search}")]
        //public async Task<ActionResult<IEnumerable<Patient>>> SearchPatient(string name)
        //{
        //    try
        //    {
                
        //        return Ok($"Patient with id {id} deleted");
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error deleting patient");
        //    }
        //}
    }
}
