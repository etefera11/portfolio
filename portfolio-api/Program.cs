using portfolio_api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<EmailService>();
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAngular", policy =>
  {
    policy.WithOrigins(
      "http://localhost:4200",
      "https://brave-plant-02fe80110.7.azurestaticapps.net",
      "https://ezana.dev"
      )
      .AllowAnyHeader()
      .AllowAnyMethod();
  });
});

var app = builder.Build();

app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();

app.Run();
