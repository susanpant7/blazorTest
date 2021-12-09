using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Server.CRUD;

namespace MyProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentInfosController : ControllerBase
    {
        private readonly IAssessmentInfoCrud assessmentInfoCrud;
        public AssessmentInfosController(IAssessmentInfoCrud assessmentInfoCrud)
        {
            this.assessmentInfoCrud = assessmentInfoCrud;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAllAssessmentInfos()
        {
            try
            {
                return Ok(await assessmentInfoCrud.GetAllAssessmentInfos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error getting data from db");
            }
            
        }

    }
}
