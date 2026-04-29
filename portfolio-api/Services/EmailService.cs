using MimeKit;
using portfolio_api.Models;
using MailKit.Net.Smtp;

namespace portfolio_api.Services
{
  public class EmailService
  {
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
      _config = config;
    }

    public async Task SendContactEmailAsync(ContactRequest request)
    {
      var message = new MimeMessage();
      message.From.Add(new MailboxAddress("Portfolio Contact", _config["Gmail:From"]));
      message.To.Add(new MailboxAddress("Ezana", _config["Gmail:From"]));
      message.Subject = $"Portfolio Contact: {request.Name}";
      message.Body = new TextPart("plain")
      {
        Text = $"Name: {request.Name}\nEmail: {request.Email}\n\nMessage:\n{request.Message}"
      };

      using var client = new SmtpClient();
      await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
      await client.AuthenticateAsync(_config["Gmail:From"], _config["Gmail:AppPassword"]);
      await client.SendAsync(message);
      await client.DisconnectAsync(true);
    }
  }
}
