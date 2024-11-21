using Microsoft.AspNetCore.Mvc;

namespace NotificationService.Controllers
{
    public class NotificationController : Controller
    {
        [HttpPost]
        [Route("api/notification/SendEmail")]
        public async Task<IActionResult> SendEmail()
        {
            try
            {
                var result = new ActionResult<int>(0);
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
