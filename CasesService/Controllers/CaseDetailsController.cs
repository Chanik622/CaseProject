using CasesService.Interfaces;
using CasesService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasesService.Controllers
{
    public class CaseDetailsController : Controller
    {
        private readonly ICaseService _caseService;
        public CaseDetailsController(ICaseService caseService)
        {
            _caseService = caseService;        
        }

        [HttpPost]
        [Route("api/cases/GetCaseDetails")]
        public async Task<IActionResult> GetCaseDetails([FromBody]filterCase filterCase)
        {
            try
            {
                if (filterCase.Equals(null))
                {
                    return BadRequest();
                }
                var result = await _caseService.GetCaseDetails(filterCase);
                if (result == null)
                    return NoContent();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }


        [HttpPost]
        [Route("api/CreateCaseDetails")]
        public async Task<IActionResult> CreateCaseDetails([FromBody] CaseDetail caseDetail)
        {
            try
            {
                if (caseDetail.Equals(null))
                {
                    return BadRequest();
                }
                var result = await _caseService.CreateCaseDetails(caseDetail);
                if (result == null)
                    return NoContent();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }
    }
}
