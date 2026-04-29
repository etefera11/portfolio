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
      if (string.IsNullOrWhiteSpace(request.Name) || request.Name.Trim().Length < 2)
        return BadRequest("Name must be at least 2 characters.");

      if (string.IsNullOrWhiteSpace(request.Email))
        return BadRequest("Email is required.");

      var emailRegex = new System.Text.RegularExpressions.Regex(
          @"^[a-zA-Z0-9._%+\-]+@[a-zA-Z0-9.\-]+\.[a-zA-Z]{2,}$");
      if (!emailRegex.IsMatch(request.Email))
        return BadRequest("Please enter a valid email address.");

      if (string.IsNullOrWhiteSpace(request.Message) || request.Message.Trim().Length < 10)
        return BadRequest("Message must be at least 10 characters.");


      await _emailService.SendContactEmailAsync(request);
      return Ok(new { message = "Message sent successfully." });
    }
  }
}
