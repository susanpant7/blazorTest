using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Server.CRUD;
using MyProject.Shared;

namespace MyProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentsController : ControllerBase
    {
        private readonly IAssessmentCrud assessmentCrud;

        public AssessmentsController(IAssessmentCrud assessmentCrud)
        {
            this.assessmentCrud = assessmentCrud;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAssessments()
        {
            try
            {
                return Ok(await assessmentCrud.GetAllAssessments());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Assessment>> GetAssessmentById(int id)
        {
            try
            {
                var assessment = await assessmentCrud.GetAssessmentById(id);
                if (assessment == null)
                {
                    return NotFound();
                }
                else
                {
                    return assessment;
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public async Task<ActionResult> AddAssessment(Assessment assessment)
        {
            try
            {
                if (assessment == null)
                {
                    return BadRequest();
                }
                var newAssessment = await assessmentCrud.CreateAssessment(assessment);
                return CreatedAtAction(nameof(GetAssessmentById),
                    new { id = newAssessment.AssessmentId }, newAssessment);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

