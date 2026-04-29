using Microsoft.AspNetCore.Mvc;
using portfolio_api.Models;
using portfolio_api.Services;

namespace portfolio_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContactController : ControllerBase
  {
    private readonly EmailService _emailService;

    public ContactController(EmailService emailService)
    {
      _emailService = emailService;
    }

    [HttpPost]
    public async Task<IActionResult> Send([FromBody] ContactRequest request)
    {
      if (string.IsNullOrWhiteSpace(request.Name) ||
          string.IsNullOrWhiteSpace(request.Email) ||
          string.IsNullOrWhiteSpace(request.Message))
      {
        return BadRequest("All fields are required.");
      }

      await _emailService.SendContactEmailAsync(request);
      return Ok(new { message = "Message sent successfully." });
    }
  }
}
